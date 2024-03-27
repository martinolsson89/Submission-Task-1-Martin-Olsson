using System.Text.RegularExpressions;

namespace UserRegistration
{
    public class UserRegistrationService
    {
        private readonly List<User> _users = [];


        // Validates the username
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


        // Validates the password
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
            // Check if password contains at least one special character
            if (!Regex.IsMatch(password, @"[!@#$%^&*()_+=\[{\]};:<>|./?,-]"))
            {
                return false;
            }

            return true;
        }

        // Validates the email
        public bool ValidateEmail(string email)
        {
            if (string.IsNullOrEmpty(email))
            {
                return false;
            }

            // Check if Email contains an @ symbol and .com OR .se OR .net OR .org
            if (!Regex.IsMatch(email, @"^[^@\s]+@[^@\s]+\.[^@\s]+$"))
            {
                return false;
            }

            return true;
        }

        //Checks if the username is unique
        public bool IsUsernameUnique(string userName)
        {
            //User lambda expression to check if username already exists even if it is in different case
            if (_users.Any(u => u.UserName.Equals(userName, StringComparison.OrdinalIgnoreCase)))
            {
                return false; // Username already exists.
            }

            return true; // Username is unique.
        }

        // Registers a new user with the given username, password and email
        public bool RegisterUser(string userName, string password, string email)
        {
            if (!ValidateUserName(userName) || !ValidatePassword(password) || !ValidateEmail(email))
            {
                Console.WriteLine($"User: {userName} was NOT registered, please check your input data (username, password and email)");
                return false;
                
            }

            if (!IsUsernameUnique(userName))
            {
                Console.WriteLine($"User: {userName} was NOT registered, due to username is already taken.");
                return false;
            }

            var user = new User(userName, password, email); // Create a new user
            _users.Add(user); // Add the user to the list of users

            Console.WriteLine($"User: {userName} was successfully registered!"); // Print a confirmation message
            return true;
        }

        // Returns the user with the given username
        public string GetUser(string userName)
        {
            var user = _users.FirstOrDefault(u => u.UserName == userName)!;
            return user.UserName;
        }

        
    }
}
