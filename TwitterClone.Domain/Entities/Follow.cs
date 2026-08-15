namespace TwitterClone.Domain.Entities
{
    public class Follow
    {
        private Guid _id;
        private Guid _followerId;
        private Guid _followeeId;

        public Follow(Guid followerId, Guid followeeId)
        {
            _id = Guid.NewGuid();
            _followerId = followerId;
            _followeeId = followeeId;
        }

        public Guid Id
        {
            get { return _id; }
        }

        public Guid FollowerId
        {
            get { return _followerId; }
            set { _followerId = value; }
        }

        public Guid FolloweeId
        {
            get { return _followeeId; }
            set { _followeeId = value; }
        }
    }

}