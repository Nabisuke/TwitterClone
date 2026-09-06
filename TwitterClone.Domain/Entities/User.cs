namespace TwitterClone.Domain.Entities
{
    public class User : BaseEntity, IFollowable, INotifiable
    {
        private string _firstName;
        private string _lastName;
        private string _email;
        private List<Guid> _inComingNotifications = new List<Guid>();
        private List<Guid> _followers = new List<Guid>();

        public User(string firstName, string lastName, string email) : base(Guid.NewGuid())
        {
            _firstName = firstName;
            _lastName = lastName;
            _email = email;
        }
        
        public void Follow(Guid userId)
        {
            if (!_followers.Contains(userId))
            {
                _followers.Add(userId);
            }
        }
        public void Unfollow(Guid userId)
        {
            if (_followers.Contains(userId))
            {
                _followers.Remove(userId);
            }
        }
        public void AddNotification(Guid notificationId)
        {
            if (!_inComingNotifications.Contains(notificationId))
            {
                _inComingNotifications.Add(notificationId);
            }
        }

    }
}