using LegacyApp;

namespace Tests;

public class UserServiceTests
{
    [Fact]
    public void AddUser_Should_Return_False_When_Email_Without_At_And_Dot()
    {
        string firstName = "name";
        string lastName = "name2";
        DateTime date = new DateTime(1980,10,10);
        int clientId = 1;
        string email = "email";
        var service = new UserService();

        bool result = service.AddUser(firstName, lastName, email, date, clientId);

        Assert.False(result);

    }
}