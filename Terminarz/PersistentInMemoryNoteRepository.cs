using System.ComponentModel;
using System.Text.Json;
using System.Text.Json.Nodes;

namespace Terminarz
{
    internal class PersistentInMemoryNoteRepository : INoteRepository
    {
        private readonly BindingList<Note> _notes = new();
        private readonly Lock _writeLock = new Lock();
        private bool _loaded;

        public void SaveAll()
        {
            WriteToFileAsync();
        }

        public long Count()
        {
            LazyLoad();
            return _notes.Count;
        }

        public void Delete(Guid id)
        {
            LazyLoad();

            for (int i = _notes.Count - 1; i >= 0; i--)
            {
                Note note = _notes[i];
                if (note.Id == id)
                    _notes.RemoveAt(i);
            }

            WriteToFileAsync();
        }

        public List<Note> FindAll(Predicate<Note> filter)
        {
            LazyLoad();
            List<Note> list = new();

            foreach (Note f in _notes)
                if (filter(f))
                    list.Add(f);

            return list;
        }

        public List<Note> FindAll()
        {
            LazyLoad();
            return _notes.ToList();
        }

        public Note? FindOne(Guid id)
        {
            LazyLoad();

            foreach (Note note in _notes)
                if (note.Id == id)
                    return note;

            return null;
        }

        public void Save(Note note)
        {
            LazyLoad();

            if (FindOne(note.Id) == null)
                _notes.Add(note);

            WriteToFileAsync();
        }

        public BindingList<Note> GetBindingList()
        {
            LazyLoad();
            return _notes;
        }

        private void WriteToFileAsync()
        {
            List<Note> list = FindAll();

            Task.Run(() =>
            {
                _writeLock.Enter();
                try
                {
                    string path = GetPath();
                    string json = JsonSerializer.Serialize(list);
                    File.WriteAllText(path, json);
                }
                finally
                {
                    _writeLock.Exit();
                }
            });
        }

        private void LazyLoad()
        {
            if (_loaded)
                return;

            _loaded = true;

            LoadIntoMemory(ParseJsonArray(LoadJsonFromFile()));
        }

        private void LoadIntoMemory(List<Note>? notes)
        {
            if (notes == null)
                return;

            foreach (Note note in notes)
                _notes.Add(note);
        }

        private List<Note>? ParseJsonArray(JsonArray arr)
        {
            try
            {
                return JsonSerializer.Deserialize<List<Note>>(arr);
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        private JsonArray LoadJsonFromFile()
        {
            string path = GetPath();

            if (!Path.Exists(path))
                return new JsonArray();

            try
            {
                string data = File.ReadAllText(path);

                JsonArray? obj = JsonSerializer.Deserialize<JsonArray>(data);
                return obj == null ? new JsonArray() : obj;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Failed reading list of notes: " + ex.Message);
            }

            return new JsonArray();
        }

        private string GetPath()
        {
            return Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "terminarz_notes.txt");
        }
    }
}
