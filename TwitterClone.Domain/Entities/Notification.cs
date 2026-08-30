namespace TwitterClone.Domain.Entities
{
    public abstract class Notification : BaseEntity
    {
        private Guid _userId = Guid.Empty;
        private string _type;
        private bool _isRead;
        private string _message;

        public Notification(string notificationType) : base(Guid.NewGuid())
        {
            _type = notificationType;
            _isRead = false;
            _message = string.Empty;
        }

        public string Message
        {
            get { return _message; }
            protected set 
            { 
                if (string.IsNullOrWhiteSpace(value))
                    throw new ArgumentException("Notification message cannot be empty.");
                    
                _message = value; 
            }
        }

        public bool IsRead
        {
            get { return _isRead; }
            set { _isRead = value; }
        }

        public string GetNotification()
        {
            return $"UserId: {_userId}, NotificationType: {_type}";
        }
        public override string DescribeRecord()
        {
            var baseRecord = base.DescribeRecord();
            return $"{baseRecord}, UserId: {_userId}, Type: {_type}, IsRead: {_isRead}, Message: {_message}";
        }

        public abstract string GetMessage();

    }
}