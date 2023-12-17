using Itmo.ObjectOrientedProgramming.Lab3.Entities;

namespace Itmo.ObjectOrientedProgramming.Lab3.Tests;

public static class MessageSystemTestData
{
    public static Message Message { get; } = new Message("Greeting", "Hello User! How are you?");
    public static Message ImportantMessage { get; } = new Message("Greeting", "Hello User! How are you?", 1);
}