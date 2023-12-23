using System;
using Itmo.ObjectOrientedProgramming.Lab4.TextFormatters;

namespace Itmo.ObjectOrientedProgramming.Lab4.Writers.Implementations;

public class ConsoleWriter : IWriter
{
    private readonly ITextFormatter _textFormatter;

    public ConsoleWriter(ITextFormatter textFormatter)
    {
        ArgumentNullException.ThrowIfNull(textFormatter);

        _textFormatter = textFormatter;
    }

    public void Write(string text)
    {
        ArgumentNullException.ThrowIfNull(text);

        Console.Write(text);
    }

    public void WriteLine(string text)
    {
        ArgumentNullException.ThrowIfNull(text);

        Console.WriteLine(text);
    }

    public void WriteTreeListDirectory(string text, int depth)
    {
        ArgumentNullException.ThrowIfNull(text);

        WriteLine(_textFormatter.TreeListDirectoryFormat(text, depth));
    }

    public void WriteTreeListFile(string text, int depth)
    {
        ArgumentNullException.ThrowIfNull(text);

        WriteLine(_textFormatter.TreeListFileFormat(text, depth));
    }
}