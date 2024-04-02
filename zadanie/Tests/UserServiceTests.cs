using LegacyApp;
using Xunit.Abstractions;

namespace Tests;

public class UserServiceTests
{
    private readonly ITestOutputHelper _testOutputHelper;

    public UserServiceTests(ITestOutputHelper testOutputHelper)
    {
        _testOutputHelper = testOutputHelper;
    }

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
    
    [Fact]
    public void AddUser_Should_Return_False_When_Age_Is_Less_Than_21()
    {
        string firstName = "art";
        string lastName = "name";
        DateTime date = new DateTime(2004,10,10);
        int clientId = 1;
        string email = "email@gmail.com";
        var service = new UserService();

        bool result = service.AddUser(firstName, lastName, email, date, clientId);

        Assert.False(result);
    }
    
    [Fact]
    public void AddUser_Should_Throw_ArgumentException_When_Client_With_Such_Id_Doesnt_Exists()
    {
        string firstName = "art";
        string lastName = "name";
        DateTime date = new DateTime(1980,10,10);
        int clientId = -5;
        string email = "email@gmail.com";
        var service = new UserService();

        Assert.Throws<ArgumentException>(() => service.AddUser(firstName, lastName, email, date, clientId));
    }
    
    [Fact]
    public void AddUser_Should_Return_False_When_User_Has_CreaditLimit_And_CreditLimit_Is_Less_Than_500()
    {
        string firstName = "art";
        string lastName = "Kowalski";
        DateTime date = new DateTime(1980,10,10);
        int clientId = 1;
        string email = "email@gmail.com";
        var service = new UserService();

        bool result = service.AddUser(firstName, lastName, email, date, clientId);
        
        Assert.False(result);
    }
    
    [Fact]
    public void AddUser_Should_Return_True_When_User_Dont_Has_CreaditLimit()
    {
        string firstName = "art";
        string lastName = "Malewski";
        DateTime date = new DateTime(1980,10,10);
        int clientId = 2;
        string email = "email@gmail.com";
        var service = new UserService();

        bool result = service.AddUser(firstName, lastName, email, date, clientId);
        
        Assert.True(result);
    }
    
    [Fact]
    public void AddUser_Should_Return_True_When_User_Has_CreaditLimit_More_Than_500()
    {
        string firstName = "art";
        string lastName = "Smith";
        DateTime date = new DateTime(1980,10,10);
        int clientId = 3;
        string email = "email@gmail.com";
        var service = new UserService();

        bool result = service.AddUser(firstName, lastName, email, date, clientId);
        
        Assert.True(result);
    }
}