namespace TwitterClone.Domain.Entities
{
    public class Message : BaseEntity
    {
        private Guid _senderId {get; set;}
        private Guid _receiverId {get; set;}
        private string _content {get; set;}

        private bool _isRead {get; set;}

        public Message(Guid senderId, Guid receiverId, string content) : base(Guid.NewGuid())
        {
            _senderId = senderId;
            _receiverId = receiverId;
            _content = content;
        }

        public override string DescribeRecord()
        {
            var baseRecord = base.DescribeRecord();
            return $"{baseRecord}, SenderId: {_senderId}, ReceiverId: {_receiverId}, Content: {_content}, IsRead: {_isRead}";
        }

    }
}