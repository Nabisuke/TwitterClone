namespace TwitterClone.Domain.Entities
{
    public class Notification
    {
        private Guid _id;
        private Guid _userId;
        private string _message;

        public Notification(Guid userId, string message)
        {
            _id = Guid.NewGuid();
            _userId = userId;
            _message = message;
        }

        public Guid Id
        {
            get { return _id; }
        }

        public Guid UserId
        {
            get { return _userId; }
            set { _userId = value; }
        }

        public string Message
        {
            get { return _message; }
            set { _message = value; }
        }
    }
}