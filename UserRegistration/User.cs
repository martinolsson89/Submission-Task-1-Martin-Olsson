namespace UserRegistration;

public class User
{
    public string UserName { get; set; } = string.Empty;
    public string Password { get; set; } = string.Empty;
    public string Email { get; set; } = string.Empty;

    public User(string userName, string password, string email)
    {
        UserName = userName;
        Password = password;
        Email = email;
    }

}