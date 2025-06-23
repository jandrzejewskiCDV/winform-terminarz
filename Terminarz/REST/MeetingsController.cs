namespace Terminarz.REST
{
    internal class MeetingsController : BaseEndpointController<Guid, Meeting>
    {
        public MeetingsController(IMeetingsRepository meetingsRepository, string endpoint) : base(meetingsRepository, endpoint) { }
    }
}
