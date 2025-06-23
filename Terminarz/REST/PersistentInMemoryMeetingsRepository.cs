
namespace Terminarz.REST
{
    internal class PersistentInMemoryMeetingsRepository :
        BasePersistentInMemoryRepository<Guid, Meeting>, IMeetingsRepository
    {
        public List<Meeting> GetMeetingsByDate()
        {
            return SortByDate(FindAll());
        }

        public List<Meeting> GetMeetingsByDate(Predicate<Meeting> filter)
        {
            return SortByDate(FindAll(filter));
        }

        private List<Meeting> SortByDate(List<Meeting> m)
        {
            m.Sort((o1, o2) => DateTime.Compare(o1.Start, o2.Start));
            return m;
        }
    }
}
