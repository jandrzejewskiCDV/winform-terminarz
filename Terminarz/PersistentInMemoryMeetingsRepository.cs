using System.ComponentModel;
using System.Text.Json;
using System.Text.Json.Nodes;

namespace Terminarz
{
    internal class PersistentInMemoryMeetingsRepository : IMeetingsRepository
    {
        private readonly BindingList<Meeting> _meetings = new();
        private readonly Lock _writeLock = new Lock();
        private bool _loaded;

        public void SaveAll()
        {
            WriteToFileAsync();
        }

        public long Count()
        {
            LazyLoad();
            return _meetings.Count;
        }

        public void Delete(Guid id)
        {
            LazyLoad();

            for (int i = _meetings.Count - 1; i >= 0; i--)
            {
                Meeting meeting = _meetings[i];
                if (meeting.Id == id)
                    _meetings.RemoveAt(i);
            }

            WriteToFileAsync();
        }

        public List<Meeting> FindAll(Predicate<Meeting> filter)
        {
            LazyLoad();
            List<Meeting> list = new();

            foreach (Meeting f in _meetings)
                if (filter(f))
                    list.Add(f);

            return list;
        }

        public List<Meeting> FindAll()
        {
            LazyLoad();
            return _meetings.ToList();
        }

        public List<Meeting> GetMeetingsByDate()
        {
            var meetings = FindAll();
            SortMeetings(meetings);
            return meetings;
        }

        public List<Meeting> GetMeetingsByDate(Predicate<Meeting> filter)
        {
            var meetings = FindAll(filter);
            SortMeetings(meetings);
            return meetings;
        }

        private void SortMeetings(List<Meeting> meetings)
        {
            meetings.Sort((o1, o2) => DateTime.Compare(o1.Start, o2.Start));
        }

        public Meeting? FindOne(Guid id)
        {
            LazyLoad();

            foreach (Meeting meeting in _meetings)
                if (meeting.Id == id)
                    return meeting;

            return null;
        }

        public void Save(Meeting meeting)
        {
            LazyLoad();

            if (FindOne(meeting.Id) == null)
                _meetings.Add(meeting);

            WriteToFileAsync();
        }

        public BindingList<Meeting> GetBindingList()
        {
            LazyLoad();
            return _meetings;
        }

        private void WriteToFileAsync()
        {
            List<Meeting> list = FindAll();

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

        private void LoadIntoMemory(List<Meeting>? meetings)
        {
            if (meetings == null)
                return;

            foreach (Meeting meeting in meetings)
                _meetings.Add(meeting);
        }

        private List<Meeting>? ParseJsonArray(JsonArray arr)
        {
            try
            {
                return JsonSerializer.Deserialize<List<Meeting>>(arr);
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
                Console.WriteLine("Failed reading list of meetings: " + ex.Message);
            }

            return new JsonArray();
        }

        private string GetPath()
        {
            return Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "terminarz_meetings.txt");
        }
    }
}
