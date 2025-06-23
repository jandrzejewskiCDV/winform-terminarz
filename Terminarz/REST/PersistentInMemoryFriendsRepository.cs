namespace Terminarz.REST
{
    internal class PersistentInMemoryFriendsRepository : 
        BasePersistentInMemoryRepository<Guid, Friend>, IFriendsRepository
    { }
}
