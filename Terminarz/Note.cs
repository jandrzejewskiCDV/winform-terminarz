namespace Terminarz
{
    internal class Note : IIdentifiable<Guid>
    {
        public Guid Identifier { get; init; } = Guid.NewGuid();
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime Created { get; init; } = DateTime.Now;
        public DateTime? Updated { get; set; }
    }
}
