namespace UserRegistration.Tests
{
    [TestClass]
    public class UserRegistrationServiceTests
    {

        private UserRegistrationService service;

        [TestInitialize]
        public void Setup()
        {
            service = new UserRegistrationService();
        }

        [TestMethod]

        public void RegisterUser_AddUser_ShouldReturnTrueAndConfirmationMessage()
        {
            // Arrange
            var userName = "JohnDoe1";
            var password = "Password!";
            var email = "john.doe@gmail.com";

            // Act
            var result = service.RegisterUser(userName, password, email);

            // Assert
            Assert.IsTrue(result, $"User:{userName}, was NOT registered");
        }

        // Username must be between 5 and 20 characters long, only alphanumeric characters are allowed.
        [DataRow("JohnD")]
        [DataRow("MaryJaneParker")]
        [DataRow("MarkTwain123")]
        [DataRow("1234567")]
        [DataTestMethod]
        public void ValidateUserName_WithValidUserName_ShouldReturnTrue(string userName)
        {
            // Act
            var result = service.ValidateUserName(userName);

            // Assert
            Assert.IsTrue(result);
        }

        [DataRow("John")]
        [DataRow("MaryJaneParkerSmithJohnson")]
        [DataRow("MarkTwain@£$€!!")]
        [DataRow("")]
        [DataTestMethod]
        public void ValidateUserName_WithInvalidUserName_ShouldReturnFalse(string userName)
        {
            // Act
            var result = service.ValidateUserName(userName);

            // Assert
            Assert.IsFalse(result);
        }

        [DataRow("pass")]
        [DataRow("password123")]
        [DataRow("")]
        [DataTestMethod]
        public void ValidatePassword_WithInvalidPassword_ShouldReturnFalse(string password)
        {
            // Act
            var result = service.ValidatePassword(password);

            // Assert
            Assert.IsFalse(result);
        }

        // Password must be at least 8 characters long and contain at least one special character.
        [DataRow("Password!")]
        [DataRow("!#¤%&/())=?")]
        [DataRow("1234567#")]
        [DataTestMethod]
        public void ValidatePassword_WithValidPassword_ShouldReturnTrue(string password)
        {
            // Act
            var result = service.ValidatePassword(password);

            // Assert
            Assert.IsTrue(result);
        }

        // Email must contain an @ symbol and .com OR .se OR .net OR .org
        [DataRow("")]
        [DataRow("john.doe")]
        [DataRow("john.doe@")]
        [DataRow("john.doe@gmail")]
        [DataTestMethod]
        public void ValidateEmail_WithInvalidEmail_ShouldReturnFalse(string email)
        {
            // Act
            var result = service.ValidateEmail(email);

            // Assert
            Assert.IsFalse(result);
        }

        [DataRow("john.doe@gmail.com")]
        [DataRow("mary.jane@yahoo.net")]
        [DataRow("kim@hotmail.se")]
        [DataRow("jim@email.org")]
        [DataTestMethod]
        public void ValidateEmail_WithValidEmail_ShouldReturnTrue(string email)
        {
            // Act
            var result = service.ValidateEmail(email);

            // Assert
            Assert.IsTrue(result);
        }

        [TestMethod]
        public void RegisterUser_ExistingUser_ReturnsFalse()
        {
            // Arrange
            var userName = "JohnDoe1";
            var userName2 = "johndoe1";

            // Act
            service.RegisterUser(userName, "Password!", "john@gmail.com");
            var result = service.IsUsernameUnique(userName2);

            Assert.IsFalse(result);
        }

    }

}