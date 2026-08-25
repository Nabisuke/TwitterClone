namespace TwitterClone.Domain.Entities
{
    public sealed class LikeNotification : Notification
    {
        private Guid _likeId { get; set; }
        private Guid _likeByUserId { get; set; }

        public LikeNotification(Guid likeId, Guid likeByUserId) : base("Like")
        {
            _likeId = likeId;
            _likeByUserId = likeByUserId;
        }

        public override string DescribeRecord()
        {
            var baseRecord = base.DescribeRecord();
            return $"{baseRecord}, LikeId: {_likeId}, LikeByUserId: {_likeByUserId}";
        }
    }
}