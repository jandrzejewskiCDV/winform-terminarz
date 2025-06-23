using System.Text.Json;
using System.Text.Json.Nodes;

namespace Terminarz.REST
{
    internal abstract class BasePersistentInMemoryRepository<TIdentifier, TEntity>
        : IRepository<TIdentifier, TEntity>
        where TEntity : IIdentifiable<TIdentifier>
        where TIdentifier : notnull
    {
        protected readonly Dictionary<TIdentifier, TEntity> _entities = new();

        private readonly SemaphoreSlim _lock = new SemaphoreSlim(1,1);

        private bool _diskRead;

        public void SaveAll()
        {
            WriteToFileAsync();
        }

        public long Count()
        {
            LazyLoad();
            return _entities.Count;
        }

        public void Delete(TIdentifier id)
        {
            LazyLoad();

            _entities.Remove(id);

            WriteToFileAsync();
        }

        public List<TEntity> FindAll(Predicate<TEntity> filter)
        {
            LazyLoad();
            return _entities.Values.Where(e => filter(e)).ToList();
        }

        public List<TEntity> FindAll()
        {
            LazyLoad();
            return _entities.Values.ToList();
        }

        public TEntity? FindOne(TIdentifier id)
        {
            LazyLoad();
            return _entities.GetValueOrDefault(id);
        }

        public void Save(TEntity entity)
        {
            LazyLoad();

            _entities[entity.Identifier] = entity;

            WriteToFileAsync();
        }

        private void WriteToFileAsync()
        {
            List<TEntity> list = FindAll();

            Task.Run(async () =>
            {
                await _lock.WaitAsync();
                try
                {
                    string path = GetPath();
                    string json = JsonSerializer.Serialize(list);
                    File.WriteAllText(path, json);
                }
                finally
                {
                    _lock.Release();
                }
            });
        }

        private void LazyLoad()
        {
            if (_diskRead)
                return;

            _diskRead = true;

            LoadIntoMemory(ParseJsonArray(LoadJsonFromFile()));
        }

        private void LoadIntoMemory(List<TEntity>? entities)
        {
            if (entities == null)
                return;

            foreach (var item in entities)
                _entities[item.Identifier] = item;
        }

        private List<TEntity>? ParseJsonArray(JsonArray arr)
        {
            try
            {
                return arr.Deserialize<List<TEntity>>();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                MessageBox.Show("Wystapil blad podczas wczytywania repozytorium");
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
                Console.WriteLine("Failed reading list of entities: " + ex.Message);
            }

            return new JsonArray();
        }

        private string GetPath()
        {
            return Path.Combine(AppDomain.CurrentDomain.BaseDirectory, $"terminarz_{typeof(TEntity).Name}.txt");
        }
    }
}
