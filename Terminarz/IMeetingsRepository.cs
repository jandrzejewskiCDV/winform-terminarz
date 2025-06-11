namespace Terminarz
{
    internal interface IMeetingsRepository : IRepository<Guid, Meeting>
    {
        List<Meeting> GetMeetingsByDate();
        List<Meeting> GetMeetingsByDate(Predicate<Meeting> filter);
    }
}
