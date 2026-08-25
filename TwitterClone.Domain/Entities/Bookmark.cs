namespace TwitterClone.Domain.Entities
{
    public class Bookmark : BaseEntity
    {
        private Guid _tweetId {get ; set;}
        private Guid _userId {get ; set;}

        public Bookmark() : base(Guid.NewGuid())
        {

        }

        public override string DescribeRecord()
        {
            var baseRecord = base.DescribeRecord();
            return $"{baseRecord}, UserId: {_userId}, TweetId: {_tweetId}";
        }
    }
}