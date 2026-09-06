namespace TwitterClone.Domain.Entities
{
    public sealed class SystemNotification : Notification
    {
        private string _message { get; set; }

        public SystemNotification(string message) : base("System")
        {
            _message = message;
        }

        public override string DescribeRecord()
        {
            var baseRecord = base.DescribeRecord();
            return $"{baseRecord}, Message: {_message}";
        }

        public override string GetMessage()
        {
            return _message;
        }
    }
}