namespace Itmo.ObjectOrientedProgramming.Lab4.TextFormatters;

public interface ITextFormatter
{
    public string TreeListDirectoryFormat(string text, int depth);
    public string TreeListFileFormat(string text, int depth);
}