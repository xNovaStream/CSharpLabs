using System;
using Itmo.ObjectOrientedProgramming.Lab4.CommandParser;
using Itmo.ObjectOrientedProgramming.Lab4.CommandParser.Builders.Implementations;
using Itmo.ObjectOrientedProgramming.Lab4.Commands.Builders.Implementations;
using Itmo.ObjectOrientedProgramming.Lab4.Commands.Implementations;
using Itmo.ObjectOrientedProgramming.Lab4.Loggers;
using Itmo.ObjectOrientedProgramming.Lab4.Writers;
using NSubstitute;
using Xunit;
using ICommand = Itmo.ObjectOrientedProgramming.Lab4.Commands.ICommand;

namespace Itmo.ObjectOrientedProgramming.Lab4.Tests;

public class CommandParserTestSuite
{
    [Fact]
    public void UnknownCommandTest()
    {
        // arrange
        string[] args = "do something unknown".Split();

        ILogger logger = Substitute.For<ILogger>();
        IWriter writer = Substitute.For<IWriter>();

        CommandData commandData = new CommandDataBuilder(args).Build();
        var commandBuilder = new CommandBuilder(logger, writer, commandData);

        // act
        ICommand command = commandBuilder.Build();

        // assert
        Assert.IsType<InvalidCommand>(command);
    }

    [Fact]
    public void LocalConnectCommandTest()
    {
        // arrange
        string[] args = "connect C:/ -m local".Split();

        ILogger logger = Substitute.For<ILogger>();
        IWriter writer = Substitute.For<IWriter>();

        CommandData commandData = new CommandDataBuilder(args).Build();
        var commandBuilder = new CommandBuilder(logger, writer, commandData);

        // act
        ICommand command = commandBuilder.Build();

        // assert
        Assert.IsType<LocalConnectCommand>(command);
    }

    [Fact]
    public void TreeGotoCommandTest()
    {
        // arrange
        string[] args = "tree goto C:/directory/".Split();

        ILogger logger = Substitute.For<ILogger>();
        IWriter writer = Substitute.For<IWriter>();

        CommandData commandData = new CommandDataBuilder(args).Build();
        var commandBuilder = new CommandBuilder(logger, writer, commandData);

        // act
        ICommand command = commandBuilder.Build();

        // assert
        Assert.IsType<TreeGotoCommand>(command);
    }

    [Theory]
    [InlineData("tree list -d 5")]
    [InlineData("tree list")]
    public void TreeListCommandTest(string commandLine)
    {
        ArgumentNullException.ThrowIfNull(commandLine);

        // arrange
        string[] args = commandLine.Split();

        ILogger logger = Substitute.For<ILogger>();
        IWriter writer = Substitute.For<IWriter>();

        CommandData commandData = new CommandDataBuilder(args).Build();
        var commandBuilder = new CommandBuilder(logger, writer, commandData);

        // act
        ICommand command = commandBuilder.Build();

        // assert
        Assert.IsType<TreeListCommand>(command);
    }

    [Theory]
    [InlineData("file show C:/directory/file.txt")]
    [InlineData("file show C:/directory/file.txt -m console")]
    public void FileShowConsoleCommandTest(string commandLine)
    {
        ArgumentNullException.ThrowIfNull(commandLine);

        // arrange
        string[] args = commandLine.Split();

        ILogger logger = Substitute.For<ILogger>();
        IWriter writer = Substitute.For<IWriter>();

        CommandData commandData = new CommandDataBuilder(args).Build();
        var commandBuilder = new CommandBuilder(logger, writer, commandData);

        // act
        ICommand command = commandBuilder.Build();

        // assert
        Assert.IsType<FileShowConsoleCommand>(command);
    }

    [Fact]
    public void FileMoveCommandTest()
    {
        // arrange
        string[] args = "file move C:/directory/move.txt C:/directory/dir/".Split();

        ILogger logger = Substitute.For<ILogger>();
        IWriter writer = Substitute.For<IWriter>();

        CommandData commandData = new CommandDataBuilder(args).Build();
        var commandBuilder = new CommandBuilder(logger, writer, commandData);

        // act
        ICommand command = commandBuilder.Build();

        // assert
        Assert.IsType<FileMoveCommand>(command);
    }

    [Fact]
    public void FileCopyCommandTest()
    {
        // arrange
        string[] args = "file copy C:/directory/copy.txt C:/directory/dir/".Split();

        ILogger logger = Substitute.For<ILogger>();
        IWriter writer = Substitute.For<IWriter>();

        CommandData commandData = new CommandDataBuilder(args).Build();
        var commandBuilder = new CommandBuilder(logger, writer, commandData);

        // act
        ICommand command = commandBuilder.Build();

        // assert
        Assert.IsType<FileCopyCommand>(command);
    }

    [Fact]
    public void FileDeleteCommandTest()
    {
        // arrange
        string[] args = "file delete C:/directory/delete.txt".Split();

        ILogger logger = Substitute.For<ILogger>();
        IWriter writer = Substitute.For<IWriter>();

        CommandData commandData = new CommandDataBuilder(args).Build();
        var commandBuilder = new CommandBuilder(logger, writer, commandData);

        // act
        ICommand command = commandBuilder.Build();

        // assert
        Assert.IsType<FileDeleteCommand>(command);
    }

    [Fact]
    public void FileRenameCommandTest()
    {
        // arrange
        string[] args = "file rename C:/directory/rename.txt newName".Split();

        ILogger logger = Substitute.For<ILogger>();
        IWriter writer = Substitute.For<IWriter>();

        CommandData commandData = new CommandDataBuilder(args).Build();
        var commandBuilder = new CommandBuilder(logger, writer, commandData);

        // act
        ICommand command = commandBuilder.Build();

        // assert
        Assert.IsType<FileRenameCommand>(command);
    }
}