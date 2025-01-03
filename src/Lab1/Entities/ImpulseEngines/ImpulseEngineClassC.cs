using System;
using Itmo.ObjectOrientedProgramming.Lab1.Entities.Environments;
using Itmo.ObjectOrientedProgramming.Lab1.Entities.Flights;
using Itmo.ObjectOrientedProgramming.Lab1.Exceptions;

namespace Itmo.ObjectOrientedProgramming.Lab1.Entities.ImpulseEngines;

public class ImpulseEngineClassC : ImpulseEngineBase
{
    private readonly double _speed;
    public ImpulseEngineClassC(double speed, double fuelConsumption, double startFuel)
        : base(fuelConsumption, startFuel)
    {
        _speed = speed > 0 ? speed : throw new InvalidSpeedException();
    }

    public override FlightReport Move(EnvironmentBase environment) => environment is NeutrinoNebulae
        ? new FlightReport(FlightResult.ImpassableEnvironment)
        : base.Move(environment);

    protected override double GetSpentTime(EnvironmentBase environment)
    {
        ArgumentNullException.ThrowIfNull(environment);

        return environment.Distance / _speed;
    }
}