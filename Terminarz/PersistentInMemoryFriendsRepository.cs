using System.ComponentModel;
using System.Text.Json;
using System.Text.Json.Nodes;

namespace Terminarz
{
    internal class PersistentInMemoryFriendsRepository : IFriendsRepository
    {
        private readonly BindingList<Friend> _friends = new();
        private readonly Lock _writeLock = new Lock();
        private bool _loaded;

        public void SaveAll()
        {
            WriteToFileAsync();
        }

        public long Count()
        {
            LazyLoad();
            return _friends.Count;
        }

        public void Delete(long id)
        {
            LazyLoad();
            
            for(int i = _friends.Count - 1; i >= 0; i--)
            {
                Friend friend = _friends[i];
                if(friend.Id == id)
                    _friends.RemoveAt(i);
            }

            WriteToFileAsync();
        }

        public List<Friend> FindAll(Predicate<Friend> filter)
        {
            LazyLoad();
            List<Friend> list = new();

            foreach (Friend f in _friends)
                if (filter(f))
                    list.Add(f);

            return list;
        }

        public List<Friend> FindAll()
        {
            LazyLoad();
            return _friends.ToList();
        }

        public Friend? FindOne(long id)
        {
            LazyLoad();
            
            foreach(Friend friend in _friends)
                if (friend.Id == id) 
                    return friend;

            return null;
        }

        public void Save(Friend friend)
        {
            LazyLoad();

            if (FindOne(friend.Id) == null)
                _friends.Add(friend);

            WriteToFileAsync();
        }

        public BindingList<Friend> GetBindingList()
        {
            LazyLoad();
            return _friends;
        }

        private void WriteToFileAsync()
        {
            List<Friend> list = FindAll();

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

        private void LoadIntoMemory(List<Friend>? friends)
        {
            if (friends == null) 
                return;

            foreach (Friend friend in friends)
                _friends.Add(friend);
        }

        private List<Friend>? ParseJsonArray(JsonArray arr)
        {
            try
            {
                return JsonSerializer.Deserialize<List<Friend>>(arr);
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
                Console.WriteLine("Failed reading list of friends: " + ex.Message);
            }

            return new JsonArray();
        }

        private string GetPath()
        {
            return Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "terminarz_friends.txt");
        }
    }
}
