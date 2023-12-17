using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Spectre.Console;

namespace Lab5.Presentation.Console;

public class CommandRunner
{
    private readonly List<ICommandProvider> _providers;

    public CommandRunner(IEnumerable<ICommandProvider> providers)
    {
        ArgumentNullException.ThrowIfNull(providers);

        _providers = providers.ToList();
    }

    public async Task Run()
    {
        IEnumerable<ICommand> commands = GetCommands();

        SelectionPrompt<ICommand> selector = new SelectionPrompt<ICommand>()
            .Title("Select action")
            .AddChoices(commands)
            .UseConverter(x => x.Name);

        ICommand selectedCommand = AnsiConsole.Prompt(selector);
        await selectedCommand.Run();
    }

    private IEnumerable<ICommand> GetCommands()
    {
        foreach (ICommandProvider provider in _providers)
        {
            if (provider.TryGetCommand(out ICommand? command))
            {
                yield return command;
            }
        }
    }
}