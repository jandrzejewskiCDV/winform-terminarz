namespace Terminarz
{
    internal class Meeting : IIdentifiable<Guid>
    {
        public Guid Identifier { get; init; } = Guid.NewGuid();
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime Start { get; set; }
        public DateTime? End { get; set; }
        public bool IsAllDay => End == null;

        public List<string> Reminders = new();

        public override string ToString()
        {
            if (IsAllDay)
                return $"{Title} (cały dzień)";

            return $"{Title} {Start:HH\\:mm} - {End:HH\\:mm}";
        }
    }
}
