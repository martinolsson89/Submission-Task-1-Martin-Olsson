namespace UserRegistration
{
    public class UserRegistrationService
    {
        public List<User> _users = new List<User>();

        public bool RegisterUser(string userName, string password, string email)
        {
            if (string.IsNullOrEmpty(userName) || string.IsNullOrEmpty(password) || string.IsNullOrEmpty(email))
            {
                return false;
            }

            var user = new User(userName, password, email);
            _users.Add(user);

            return true;
        }

        
    }
}
