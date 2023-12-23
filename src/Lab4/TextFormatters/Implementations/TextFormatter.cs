using System;
using System.Linq;
using Itmo.ObjectOrientedProgramming.Lab4.Exceptions;

namespace Itmo.ObjectOrientedProgramming.Lab4.TextFormatters.Implementations;

public class TextFormatter : ITextFormatter
{
    public string TreeListDirectoryFormat(string text, int depth)
    {
        ArgumentNullException.ThrowIfNull(text);
        if (depth < 0) throw new InvalidDepthException();

        return string.Concat(Enumerable.Repeat(" ", depth)) + text;
    }

    public string TreeListFileFormat(string text, int depth)
    {
        ArgumentNullException.ThrowIfNull(text);
        if (depth < 0) throw new InvalidDepthException();

        return string.Concat(Enumerable.Repeat(" ", depth)) + text;
    }
}