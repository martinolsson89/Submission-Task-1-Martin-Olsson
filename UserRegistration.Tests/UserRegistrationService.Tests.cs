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

        // Username must be between 5 and 20 characters long, only alphanumeric characters are allowed.

        // Test data for ValidateUserName
        [DataRow("JohnD")]
        [DataRow("MaryJaneParker")]
        [DataRow("MarkTwain123")]
        [DataRow("1234567")]
        [DataTestMethod]
        public void ValidateUserName_WithValidUsername_ShouldReturnTrue(string userName)
        {
            // Act
            var result = service.ValidateUserName(userName);

            // Assert
            Assert.IsTrue(result);
        }


        // Test data for ValidateUserName with invalid usernames
        [DataRow("John")]
        [DataRow("MaryJaneParkerSmithJohnson")]
        [DataRow("MarkTwain@£$€!!")]
        [DataRow("")]
        [DataTestMethod]
        public void ValidateUserName_WithInvalidUsername_ShouldReturnFalse(string userName)
        {
            // Act
            var result = service.ValidateUserName(userName);

            // Assert
            Assert.IsFalse(result);
        }

        // Password must be at least 8 characters long and contain at least one special character.
        //Test data for ValidatePassword
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

        // Test data for ValidatePassword with invalid passwords
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

        // Email must contain an @ symbol and .com OR .se OR .net OR .org
        // Test data for ValidateEmailAddress
        [DataRow("john.doe@gmail.com")]
        [DataRow("mary.jane@yahoo.net")]
        [DataRow("kim@hotmail.se")]
        [DataRow("jim@email.org")]
        [DataTestMethod]
        public void ValidateEmailAddress_WithValidEmail_ShouldReturnTrue(string email)
        {
            // Act
            var result = service.ValidateEmail(email);

            // Assert
            Assert.IsTrue(result);
        }

        // Test data for ValidateEmailAddress with invalid emails
        [DataRow("")]
        [DataRow("john.doe")]
        [DataRow("john.doe@")]
        [DataRow("john.doe@gmail")]
        [DataTestMethod]
        public void ValidateEmailAddress_WithInvalidEmail_ShouldReturnFalse(string email)
        {
            // Act
            var result = service.ValidateEmail(email);

            // Assert
            Assert.IsFalse(result);
        }

        // Username must be unique
        // Test data for RegisterUser with existing username
        [TestMethod]
        public void RegisterUser_WithExistingUsername_ShouldReturnFalse()
        {
            // Arrange
            var userName = "JohnDoe1";
            var userName2 = "johndoe1";

            // Act
            service.RegisterUser(userName, "Password!", "john@gmail.com");
            var result = service.RegisterUser(userName2, "myNameIsJoe#", "john.doe@hotmail.com");

            Assert.IsFalse(result);
        }

        // Verify that the user is registered with the correct data in the list.
        [TestMethod]
        public void RegisterUser_ValidateThatUserDataIsRegistered_ListDataShouldEqualUsername()
        {
            // Arrange
            var userName = "MaryJane2";
            var password = "Spiderman!";
            var email = "mary@yahoo.se";

            // Act
            service.RegisterUser(userName, password, email);
            var registeredUser = service.GetUser(userName);


            // Assert
            Assert.AreEqual(userName, registeredUser);

        }

        // RegisterUser should return true and a confirmation message if the user was successfully registered with valid data.
        [TestMethod]
        public void RegisterUser_WithValidData_ShouldReturnTrueAndWriteOutConfirmationMessage()
        {
            // Arrange
            var userName = "JohnDoe1";
            var password = "Password!";
            var email = "john.doe@gmail.com";

            // Act
            var result = service.RegisterUser(userName, password, email);

            // Assert
            Assert.IsTrue(result);
        }

        // RegisterUser with invalid Data should return false which means that user was not registered.
        [TestMethod]
        public void RegisterUser_WithInvalidData_ShouldReturnFalse()
        {
            // Arrange
            var userName = "John";

            // Act
            var result = service.RegisterUser(userName, "Password!", "john@gmail");

            // Assert
            Assert.IsFalse(result);
        }
    }

}