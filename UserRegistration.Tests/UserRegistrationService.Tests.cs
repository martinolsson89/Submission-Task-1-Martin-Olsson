namespace UserRegistration.Tests
{
    [TestClass]
    public class UserRegistrationServiceTests
    {
        [TestMethod]

        public void RegisterUser_WithValidData_ShouldReturnTrue_AndCountOfOne()
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
    }
}