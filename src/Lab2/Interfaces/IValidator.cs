using Itmo.ObjectOrientedProgramming.Lab2.Entities;
using Itmo.ObjectOrientedProgramming.Lab2.Entities.Validations;

namespace Itmo.ObjectOrientedProgramming.Lab2.Interfaces;

public interface IValidator
{
    public ValidationReport Validate(Computer computer);
}