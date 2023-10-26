using System;
using Itmo.ObjectOrientedProgramming.Lab3.Exceptions;

namespace Itmo.ObjectOrientedProgramming.Lab3.Entities.Users;

public class UserMessage : Message
{
    public UserMessage(string header, string text, uint importanceLevel)
        : base(header, text, importanceLevel)
    {
    }

    public UserMessage(Message message)
        : base(
            message?.Header ?? throw new ArgumentNullException(nameof(message)),
            message.Text,
            message.ImportanceLevel)
    {
    }

    public UserMessageStatus Status { get; private set; } = UserMessageStatus.Unread;

    public void Read()
    {
        if (Status == UserMessageStatus.Read) throw new InvalidMessageStatusException();

        Status = UserMessageStatus.Read;
    }
}