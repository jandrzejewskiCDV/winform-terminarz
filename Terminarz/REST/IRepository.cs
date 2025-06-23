using System.ComponentModel;

namespace Terminarz.REST
{
    internal interface IRepository<TIdentifier, TEntity>
    {
        void Save(TEntity entity);
        void SaveAll();
        void Delete(TIdentifier id);
        TEntity? FindOne(TIdentifier id);
        List<TEntity> FindAll(Predicate<TEntity> filter);
        List<TEntity> FindAll();
        long Count();
    }
}
