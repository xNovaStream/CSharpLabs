using System;
using Itmo.ObjectOrientedProgramming.Lab3.Entities.Loggers;
using Itmo.ObjectOrientedProgramming.Lab3.Exceptions;
using static Crayon.Output;

namespace Itmo.ObjectOrientedProgramming.Lab3.Entities.Displays;

public class DisplayDriver
{
    private readonly ILogger _logger;

    public DisplayDriver(string name, ILogger logger, DisplayColor color)
    {
        ArgumentNullException.ThrowIfNull(name);
        ArgumentNullException.ThrowIfNull(logger);

        Name = string.IsNullOrEmpty(name) ? throw new EmptyNameException() : name;
        _logger = logger;
        Color = color;
    }

    public string Name { get; }

    public DisplayColor Color { get; set; }

    public void Clear()
    {
        _logger.Log($"Display driver {Name} cleared\n");
    }

    public void WriteText(string text)
    {
        ArgumentNullException.ThrowIfNull(text);

        string coloredText = Color switch
        {
            DisplayColor.Black => Black(text),
            DisplayColor.Red => Red(text),
            DisplayColor.Green => Green(text),
            DisplayColor.Yellow => Yellow(text),
            DisplayColor.Blue => Blue(text),
            DisplayColor.Magenta => Magenta(text),
            DisplayColor.Cyan => Cyan(text),
            DisplayColor.White => White(text),
            _ => throw new NotImplementedException(),
        };

        _logger.Log($"Display driver {Name}\n" +
                    $"{coloredText}\n");
    }
}