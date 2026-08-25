namespace TwitterClone.Domain.Entities
{
    public class Follow : BaseEntity
    {
        private Guid _followerId {get; set;}
        private Guid _followeeId {get; set;}

        public Follow(Guid followerId, Guid followeeId) : base(Guid.NewGuid())
        {
            _followerId = followerId;
            _followeeId = followeeId;
        }

        public override string DescribeRecord()
        {
            var baseRecord = base.DescribeRecord();
            return $"{baseRecord}, FollowerId: {_followerId}, FolloweeId: {_followeeId}";
        }

    }

}