namespace Terminarz.REST
{
    internal class NotesController : BaseEndpointController<Guid, Note>
    {
        public NotesController(INotesRepository notesRepository, string endpoint) : base(notesRepository, endpoint) { }
    }
}
