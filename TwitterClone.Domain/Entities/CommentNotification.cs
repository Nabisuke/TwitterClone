
namespace TwitterClone.Domain.Entities
{
    public sealed class CommentNotification : Notification
    {
        private Guid _commentId { get; set;}
        private Guid _tweetId { get; set;}

        public CommentNotification(Guid commentId, Guid tweetId) : base("Comment")
        {
            _commentId = commentId;
            _tweetId = tweetId;
        }
        public override string DescribeRecord()
        {
            var baseRecord = base.DescribeRecord();
            return $"{baseRecord}, CommentId: {_commentId}, TweetId: {_tweetId}";
        }

    }
    
}