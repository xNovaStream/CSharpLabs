namespace Itmo.ObjectOrientedProgramming.Lab4.Writers;

public interface IWriter
{
    public void Write(string text);
    public void WriteLine(string text);
    public void WriteTreeListDirectory(string text, int depth);
    public void WriteTreeListFile(string text, int depth);
}