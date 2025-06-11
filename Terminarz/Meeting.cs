namespace Terminarz
{
    internal class Meeting
    {
        public readonly Guid Id;
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime Start { get; set; }
        public DateTime? End { get; set; }
        public bool IsAllDay => End == null;

        public List<string> Reminders = new();

        public Meeting()
        {
            Id = Guid.NewGuid();
        }

        public override string ToString()
        {
            if (IsAllDay)
                return $"{Title} (cały dzień)";

            return $"{Title} {Start:HH\\:mm} - {End:HH\\:mm}";
        }
    }
}
