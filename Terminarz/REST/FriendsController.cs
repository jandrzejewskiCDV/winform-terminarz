namespace Terminarz.REST
{
    internal class FriendsController : BaseEndpointController<Guid, Friend>
    {
        public FriendsController(IFriendsRepository friendsRepository, string endpoint) : base(friendsRepository, endpoint){}
    }
}
