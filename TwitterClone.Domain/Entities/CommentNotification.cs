
namespace TwitterClone.Domain.Entities
{
    public class CommentNotification : Notification
    {
        private Guid _commentId;
        private Guid _tweetId;

        public CommentNotification(Guid commentId, Guid tweetId) : base("Comment")
        {
            _commentId = commentId;
            _tweetId = tweetId;
        }

        public Guid CommentId
        {
            get { return _commentId; }
            set { _commentId = value; }
        }

        public Guid TweetId
        {
            get { return _tweetId; }
            set { _tweetId = value; }
        }
    }
    
}