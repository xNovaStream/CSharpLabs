using System;

namespace Itmo.ObjectOrientedProgramming.Lab3.Entities;

public class Message
{
    public Message(string header, string text, uint importanceLevel = 0)
    {
        ArgumentNullException.ThrowIfNull(header);
        ArgumentNullException.ThrowIfNull(text);

        Header = header;
        Text = text;
        ImportanceLevel = importanceLevel;
    }

    public string Header { get; }
    public string Text { get; }
    public uint ImportanceLevel { get; }
}