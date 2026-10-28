using TwitterClone.Domain.Entities;

namespace TwitterClone.Api.Data
{
    public class UserRepository
    {
        private List<User> _users { get; set; } = new List<User>();

        public User AddUser(User user)
        {
            _users.Add(user);
            return user;
        }

        public User UpdateUser(User user)
        {
            var existingUser = _users.SingleOrDefault(u => u.Id == user.Id);
            if (existingUser != null)
            {
                _users.Remove(existingUser);
                _users.Add(user);
            }
            return user;
        }

        public User DeleteUser(Guid id)
        {
            var user = _users.SingleOrDefault(u => u.Id == id);
            if (user != null)
            {
                _users.Remove(user);
            }
            return user;
        }

        public User GetUserById(Guid id)
        {
            return _users.SingleOrDefault(u => u.Id == id);
        }

        public User GetUserByEmail(string email)
        {
            return _users.SingleOrDefault(u => u.Email == email);
        }

        public List<User> GetUsers()
        {
            return _users;
        }
    }
}
