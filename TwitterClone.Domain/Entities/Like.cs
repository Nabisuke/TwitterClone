namespace TwitterClone.Domain.Entities
{
    public class Like
    {
        private Guid _id;
        private Guid _tweetId;
        private Guid _userId;

        public Like(Guid tweetId, Guid userId)
        {
            _id = Guid.NewGuid();
            _tweetId = tweetId;
            _userId = userId;
        }

        public Guid Id
        {
            get { return _id; }
        }

        public Guid TweetId
        {
            get { return _tweetId; }
            set { _tweetId = value; }
        }

        public Guid UserId
        {
            get { return _userId; }
            set { _userId = value; }
        }
    }
}