namespace TwitterClone.Domain.Entities
{
    public class Retweet : BaseEntity
    {
        private Guid _tweetId {get; set; }
        private Guid _userId {get; set; }

        public Retweet(Guid tweetId, Guid userId) : base(Guid.NewGuid())
        {
            _tweetId = tweetId;
            _userId = userId;
        }

    }
}