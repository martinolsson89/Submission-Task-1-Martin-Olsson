using System.Text.RegularExpressions;

namespace UserRegistration
{
    public class UserRegistrationService
    {
        private readonly List<User> _users = [];

        public bool RegisterUser(string userName, string password, string email)
        {
            if (!ValidateUserName(userName) || !ValidatePassword(password) || !ValidateEmail(email))
            {
                return false;
            }

            if (!IsUsernameUnique(userName))
            {
                return false;
            }

            var user = new User(userName, password, email);
            _users.Add(user);

            return true;
        }

        // Returns the user with the given username
        public string GetUser(string userName)
        {
            var user = _users.FirstOrDefault(u => u.UserName == userName)!;
            return user.UserName;
        }

        // Returns the user with the given email
        public string GetUserByEmail(string email)
        {
            var user = _users.FirstOrDefault(u => u.Email == email)!;
            return user.Email;
        }

        // Returns the user with the given password
        public string GetUserByPassword(string password)
        {
            var user = _users.FirstOrDefault(u => u.Password == password)!;
            return user.Password;
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

        public bool ValidatePassword(string password)
        {
            if (string.IsNullOrEmpty(password))
            {
                return false;
            }

            if (password.Length < 8)
            {
                return false;
            }
            if (!Regex.IsMatch(password, @"[!@#$%^&*()_+=\[{\]};:<>|./?,-]"))
            {
                return false;
            }

            return true;
        }

        public bool ValidateEmail(string email)
        {
            if (string.IsNullOrEmpty(email))
            {
                return false;
            }

            //Email must contain an @ symbol and .com OR .se OR .net OR .org
            if (!Regex.IsMatch(email, @"^[^@\s]+@[^@\s]+\.[^@\s]+$"))
            {
                return false;
            }

            return true;
        }

        public bool IsUsernameUnique(string userName)
        {
            //User lambda expression to check if username already exists even if it is in different case
            if (_users.Any(u => u.UserName.Equals(userName, StringComparison.OrdinalIgnoreCase)))
            {
                return false; // Username already exists.
            }

            return true;
        }



        
    }
}
