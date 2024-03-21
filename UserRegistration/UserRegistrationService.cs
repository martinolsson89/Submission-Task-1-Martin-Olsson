using System.Text.RegularExpressions;

namespace UserRegistration
{
    public class UserRegistrationService
    {
        public List<User> _users = new List<User>();

        public bool RegisterUser(string userName, string password, string email)
        {
            var user = new User(userName, password, email);
            _users.Add(user);

            return true;
        }

        //Username must be between 5 and 20 characters long, only alphanumeric characters are allowed
        public bool ValidateUserName(string userName)
        {
            if (string.IsNullOrEmpty(userName))
            {
                return false;
            }

            if (userName.Length < 5 || userName.Length > 20)
            {
                return false;
            }
            
            if (!Regex.IsMatch(userName, @"^[a-zA-Z0-9]+$"))
            {
                return false;
            }

            return true;
        }



        
    }
}
