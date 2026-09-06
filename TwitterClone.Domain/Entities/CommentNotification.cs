
namespace TwitterClone.Domain.Entities
{
    public sealed class CommentNotification : Notification
    {
        private Guid _commentId { get; set;}
        private Guid _tweetId { get; set;}

        private Guid _commentedByUserId { get; set; }

        public CommentNotification(Guid commentId, Guid tweetId, Guid commentedByUserId) : base("Comment")
        {
            _commentId = commentId;
            _tweetId = tweetId;
            _commentedByUserId = commentedByUserId;
        }
        public override string DescribeRecord()
        {
            var baseRecord = base.DescribeRecord();
            return $"{baseRecord}, CommentId: {_commentId}, TweetId: {_tweetId}, CommentedById: {_commentedByUserId}";
        }

        public override string GetMessage()
        {
            return $"User with ID {_commentedByUserId} commented on your tweet with ID {_tweetId}.";
        }

    }
    
}