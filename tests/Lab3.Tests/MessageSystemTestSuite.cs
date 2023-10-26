using Itmo.ObjectOrientedProgramming.Lab3.Entities;
using Itmo.ObjectOrientedProgramming.Lab3.Entities.Addressees;
using Itmo.ObjectOrientedProgramming.Lab3.Entities.Addressees.Implementations;
using Itmo.ObjectOrientedProgramming.Lab3.Entities.Loggers;
using Itmo.ObjectOrientedProgramming.Lab3.Entities.Users;
using Itmo.ObjectOrientedProgramming.Lab3.Exceptions;
using NSubstitute;
using Xunit;

namespace Itmo.ObjectOrientedProgramming.Lab3.Tests;

public class MessageSystemTestSuite
{
    [Fact]
    public void NewUserMessageTest()
    {
        // arrange
        var user = new User("User", 18);
        var message = new Message("Greeting", "Hello User! How are you?");

        // act
        user.GetMessage(message);
        UserMessageStatus newMessageStatus = user.Messages[0].Status;

        // assert
        Assert.Equal(UserMessageStatus.Unread, newMessageStatus);
    }

    [Fact]
    public void ReadNewUserMessageTest()
    {
        // arrange
        var user = new User("User", 18);
        var message = new Message("Greeting", "Hello User! How are you?");

        // act
        user.GetMessage(message);
        UserMessage userMessage = user.Messages[0];
        userMessage.Read();

        // assert
        Assert.Equal(UserMessageStatus.Read, userMessage.Status);
    }

    [Fact]
    public void ReadOldUserMessage()
    {
        // arrange
        var user = new User("User", 18);
        var message = new Message("Greeting", "Hello User! How are you?");

        // act
        user.GetMessage(message);
        UserMessage userMessage = user.Messages[0];
        userMessage.Read();
        void Action() => userMessage.Read();

        // assert
        Assert.Throws<InvalidMessageStatusException>(Action);
    }

    [Fact]
    public void ProtectedAddresseeTest()
    {
        // arrange
        IAddressee addressee = Substitute.For<IAddressee>();
        var protectedAddressee = new ProtectedAddressee(addressee, 5);
        var message = new Message("Greeting", "Hello User! How are you?", 1);

        // act
        protectedAddressee.GetMessage(message);

        // assert
        addressee.DidNotReceive().GetMessage(message);
    }

    [Fact]
    public void LoggingAddresseeTest()
    {
        // arrange
        IAddressee addressee = Substitute.For<IAddressee>();
        ILogger logger = Substitute.For<ILogger>();
        var loggingAddressee = new LoggingAddressee(addressee, logger);
        var message = new Message("Greeting", "Hello User! How are you?");

        // act
        loggingAddressee.GetMessage(message);

        // assert
        addressee.Received().GetMessage(message);
        logger.Received().Log("Log\n" +
                              "Addressee got message\n");
    }

    [Fact]
    public void MessengerTest()
    {
        // arrange
        ILogger logger = Substitute.For<ILogger>();
        var messenger = new Messenger("VK", logger);
        var addressee = new MessengerAddressee(messenger);
        var message = new Message("Greeting", "Hello User! How are you?");

        // act
        addressee.GetMessage(message);

        // assert
        logger.Received().Log("Messenger VK\n" +
                              "Greeting\n" +
                              "Hello User! How are you?\n");
    }
}