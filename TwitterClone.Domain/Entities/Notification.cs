namespace TwitterClone.Domain.Entities
{
    public class Notification : BaseEntity
    {
        private Guid _userId;
        private string _type;
        private bool _isRead;
        private string _message;

        public Notification(string notificationType) : base(Guid.NewGuid())
        {
            _type = notificationType;
            _isRead = false;
            _message = string.Empty;
        }

        public Guid UserId
        {
            get { return _userId; }
            set { _userId = value; }
        }

        public string Type
        {
            get { return _type; }
            set { _type = value; }
        }

        public bool IsRead
        {
            get { return _isRead; }
            set { _isRead = value; }
        }

        public string Message
        {
            get { return _message; }
            set { _message = value; }
        }
    }
}