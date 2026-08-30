namespace TwitterClone.Domain.Entities
{
    public sealed class MentionNotification : Notification
    {
        private Guid _mentionedByUserId { get; set; }
        private Guid _tweetId { get; set; }

        public MentionNotification(Guid mentionedByUserId, Guid tweetId) : base("Mention")
        {
            _mentionedByUserId = mentionedByUserId;
            _tweetId = tweetId;
        }

        public override string DescribeRecord()
        {
            var baseRecord = base.DescribeRecord();
            return $"{baseRecord}, MentionedByUserId: {_mentionedByUserId}, TweetId: {_tweetId}";
        }

        public override string GetMessage()
        {
            return $"User with ID {_mentionedByUserId} mentioned you in a tweet with ID {_tweetId}.";
        }
    }
}