using Itmo.ObjectOrientedProgramming.Lab2.Entities;
using Itmo.ObjectOrientedProgramming.Lab2.Entities.Validations;

namespace Itmo.ObjectOrientedProgramming.Lab2.Interfaces;

public interface IComputerBuilder
{
    public Computer Build(
        IComponentsMarket market,
        IValidator computerValidator,
        out ValidationReport validationReport);
}