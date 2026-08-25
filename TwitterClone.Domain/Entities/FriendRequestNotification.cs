namespace TwitterClone.Domain.Entities
{
    public sealed class FriendRequestNotification : Notification
    {
        private Guid _friendRequestId { get; set; }
        private Guid _requestedByUserId { get; set; }

        public FriendRequestNotification(Guid friendRequestId, Guid requestedByUserId) : base("FriendRequest")
        {
            _friendRequestId = friendRequestId;
            _requestedByUserId = requestedByUserId;
        }

        public override string DescribeRecord()
        {
            var baseRecord = base.DescribeRecord();
            return $"{baseRecord}, FriendRequestId: {_friendRequestId}, RequestedByUserId: {_requestedByUserId}";
        }
    }
}