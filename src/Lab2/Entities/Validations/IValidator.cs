using Itmo.ObjectOrientedProgramming.Lab2.Entities.Validations.Implementations;

namespace Itmo.ObjectOrientedProgramming.Lab2.Entities.Validations;

public interface IValidator
{
    public ValidationReport Validate(Computer computer);
}