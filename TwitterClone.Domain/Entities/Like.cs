namespace TwitterClone.Domain.Entities
{
    public class Like : BaseEntity
    {
        private Guid _tweetId {get; set;}
        private Guid _userId {get; set;}

        public Like(Guid tweetId, Guid userId) : base(Guid.NewGuid())
        {
            _tweetId = tweetId;
            _userId = userId;
        }
        
        public override string DescribeRecord()
        {
            var baseRecord = base.DescribeRecord();
            return $"{baseRecord}, UserId: {_userId}, TweetId: {_tweetId}";
        }


    }
}