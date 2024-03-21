namespace UserRegistration.Tests
{
    [TestClass]
    public class UserRegistrationServiceTests
    {
        [TestMethod]

        public void RegisterUser_AddUserInformation_ShouldReturnTrueAndCountOfOne()
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
            Assert.AreEqual(1, service._users.Count);
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
    }

}