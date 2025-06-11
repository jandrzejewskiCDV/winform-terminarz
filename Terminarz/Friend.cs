
using System.ComponentModel;

namespace Terminarz
{
    internal class Friend
    {
        [Browsable(false)]
        public long Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string PhoneNumbers { get; set; }
        public string Emails { get; set; }

        public override bool Equals(object? obj)
        {
            return obj is Friend friend &&
                   Name == friend.Name &&
                   Surname == friend.Surname &&
                   PhoneNumbers == friend.PhoneNumbers &&
                   Emails == friend.Emails;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(Name, Surname, PhoneNumbers, Emails);
        }
    }
}
