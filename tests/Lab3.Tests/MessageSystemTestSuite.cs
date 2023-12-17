using Itmo.ObjectOrientedProgramming.Lab3.Entities.Addressees;
using Itmo.ObjectOrientedProgramming.Lab3.Entities.Addressees.Implementations;
using Itmo.ObjectOrientedProgramming.Lab3.Entities.Loggers;
using Itmo.ObjectOrientedProgramming.Lab3.Entities.Messengers.Implementations;
using Itmo.ObjectOrientedProgramming.Lab3.Entities.Topics;
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

        // act
        user.GetMessage(MessageSystemTestData.Message);
        UserMessageStatus newMessageStatus = user.Messages[0].Status;

        // assert
        Assert.Equal(UserMessageStatus.Unread, newMessageStatus);
    }

    [Fact]
    public void ReadNewUserMessageTest()
    {
        // arrange
        var user = new User("User", 18);

        // act
        user.GetMessage(MessageSystemTestData.Message);
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

        // act
        user.GetMessage(MessageSystemTestData.Message);
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

        // act
        protectedAddressee.SendMessage(MessageSystemTestData.ImportantMessage);

        // assert
        addressee.DidNotReceive().SendMessage(MessageSystemTestData.ImportantMessage);
    }

    [Fact]
    public void LoggingAddresseeTest()
    {
        // arrange
        IAddressee addressee = Substitute.For<IAddressee>();
        ILogger logger = Substitute.For<ILogger>();
        var loggingAddressee = new LoggingAddressee(addressee, logger);

        // act
        loggingAddressee.SendMessage(MessageSystemTestData.Message);

        // assert
        addressee.Received().SendMessage(MessageSystemTestData.Message);
        logger.Received().Log("Addressee got message\n");
    }

    [Fact]
    public void MessengerTest()
    {
        // arrange
        ILogger logger = Substitute.For<ILogger>();
        var messenger = new Messenger("VK", logger);
        var addressee = new MessengerAddressee(messenger);

        // act
        addressee.SendMessage(MessageSystemTestData.Message);

        // assert
        logger.Received().Log("Messenger VK\n" +
                              MessageSystemTestData.Message.Header + '\n' +
                              MessageSystemTestData.Message.Text + "\n");
    }

    [Fact]
    public void TopicRepositoryTest()
    {
        // arrange
        IAddressee addressee = Substitute.For<IAddressee>();
        var topic = new Topic("Topic", addressee);
        var topicRepository = new TopicRepository();

        // act
        topicRepository.Add(topic);
        topicRepository.Get("Topic").Send(MessageSystemTestData.Message);

        // assert
        addressee.Received().SendMessage(MessageSystemTestData.Message);
    }
}