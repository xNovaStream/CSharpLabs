using System;
using Itmo.ObjectOrientedProgramming.Lab3.Exceptions;

namespace Itmo.ObjectOrientedProgramming.Lab3.Entities;

public class Message
{
    public Message(string header, string text, int importanceLevel = 0)
    {
        ArgumentNullException.ThrowIfNull(header);
        ArgumentNullException.ThrowIfNull(text);

        Header = header;
        Text = text;
        ImportanceLevel = importanceLevel >= 0 ? importanceLevel : throw new InvalidImportanceLevelException();
    }

    public string Header { get; }
    public string Text { get; }
    public int ImportanceLevel { get; }
}