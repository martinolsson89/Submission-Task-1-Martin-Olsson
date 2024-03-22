namespace UserRegistration.Tests
{
    [TestClass]
    public class UserRegistrationServiceTests
    {
        [TestMethod]

        public void RegisterUser_AddUserInformation_ShouldReturnTrueAndValidationOfDataAdded()
        {
            // Arrange
            var service = new UserRegistrationService();
            var userName = "JohnDoe";
            var password = "abc123";
            var email = "john.doe@gmail.com";

            // Act
            var result = service.RegisterUser(userName, password, email);

            // Assert
            Assert.IsTrue(result);
            Assert.AreEqual(userName, service.GetUser(userName));
            Assert.AreEqual(password, service.GetUserByPassword(password));
            Assert.AreEqual(email, service.GetUserByEmail(email));

        }

        // Username must be between 5 and 20 characters long, only alphanumeric characters are allowed.
        [DataRow("JohnD")]
        [DataRow("MaryJaneParker")]
        [DataRow("MarkTwain123")]
        [DataRow("1234567")]
        [DataTestMethod]
        public void ValidateUserName_WithValidUserName_ShouldReturnTrue(string userName)
        {
            // Arrange
            var service = new UserRegistrationService();
            

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
            // Arrange
            var service = new UserRegistrationService();

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
            // Arrange
            var service = new UserRegistrationService();

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
            // Arrange
            var service = new UserRegistrationService();

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
            // Arrange
            var service = new UserRegistrationService();

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
            // Arrange
            var service = new UserRegistrationService();

            // Act
            var result = service.ValidateEmail(email);

            // Assert
            Assert.IsTrue(result);
        }

        [TestMethod]
        public void RegisterUser_ExistingUser_Failure()
        {
            // Arrange
            var service = new UserRegistrationService();
            var userName = "JohnDoe!";
            var userName2 = "johndoe!";

            // Act
            service.RegisterUser(userName, "abc123", "john@gmail.com");
            var result = service.IsUsernameUnique(userName2);

            Assert.IsFalse(result);
        }

    }

}