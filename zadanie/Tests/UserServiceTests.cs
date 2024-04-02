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
    
    [Fact]
    public void AddUser_Should_Return_False_When_Email_Without_At()
    {
        string firstName = "name";
        string lastName = "name2";
        DateTime date = new DateTime(1980,10,10);
        int clientId = 1;
        string email = "email.com";
        var service = new UserService();

        bool result = service.AddUser(firstName, lastName, email, date, clientId);

        Assert.False(result);
    }
    
    [Fact]
    public void AddUser_Should_Return_False_When_Email_Without_Dot()
    {
        string firstName = "name";
        string lastName = "name2";
        DateTime date = new DateTime(1980,10,10);
        int clientId = 1;
        string email = "email@gmailcom";
        var service = new UserService();

        bool result = service.AddUser(firstName, lastName, email, date, clientId);

        Assert.False(result);
    }
    
    [Fact]
    public void AddUser_Should_Return_False_When_FirstName_Is_Null()
    {
        string firstName = null;
        string lastName = "name2";
        DateTime date = new DateTime(1980,10,10);
        int clientId = 1;
        string email = "email";
        var service = new UserService();

        bool result = service.AddUser(firstName, lastName, email, date, clientId);

        Assert.False(result);
    }
    
    [Fact]
    public void AddUser_Should_Return_False_When_FirstName_Is_Empty()
    {
        string firstName = "";
        string lastName = "name2";
        DateTime date = new DateTime(1980,10,10);
        int clientId = 1;
        string email = "email";
        var service = new UserService();

        bool result = service.AddUser(firstName, lastName, email, date, clientId);

        Assert.False(result);
    }
    
    [Fact]
    public void AddUser_Should_Return_False_When_LastName_Is_Null()
    {
        string firstName = "art";
        string lastName = null;
        DateTime date = new DateTime(1980,10,10);
        int clientId = 1;
        string email = "email";
        var service = new UserService();

        bool result = service.AddUser(firstName, lastName, email, date, clientId);

        Assert.False(result);
    }
    
    [Fact]
    public void AddUser_Should_Return_False_When_LastName_Is_Empty()
    {
        string firstName = "art";
        string lastName = "";
        DateTime date = new DateTime(1980,10,10);
        int clientId = 1;
        string email = "email";
        var service = new UserService();

        bool result = service.AddUser(firstName, lastName, email, date, clientId);

        Assert.False(result);
    }
    
    // [Fact]
    // public void IsAgeShouldBeRounded_Should_Return_True_When_Month_Of_Birth_Is_Less_Than_Todays_Month()
    // {
    //     DateTime now = DateTime.Now;
    //     DateTime date = new DateTime(now.Year - 5,now.Month - 1,10);
    //
    //
    //     Assert.False(result);
    // }
}