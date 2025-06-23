namespace Terminarz.REST
{
    internal class PersistentInMemoryNoteRepository : 
        BasePersistentInMemoryRepository<Guid, Note>, INotesRepository{}
}
