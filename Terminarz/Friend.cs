namespace Terminarz
{
    internal class Friend : IIdentifiable<Guid>
    {
        public Guid Identifier { get; init; } = Guid.NewGuid();
        public string Name { get; set; }
        public string Surname { get; set; }
        public List<string> PhoneNumbers { get; init; } = new();
        public List<string> Emails { get; init; } = new();
        public List<string> SocialMedia { get; init; } = new();
        public string? PhotoPath { get; set; }

        public override bool Equals(object? obj)
        {
            return obj is Friend friend &&
                   Identifier.Equals(friend.Identifier);
        }
    }
}
