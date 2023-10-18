using System;
using Itmo.ObjectOrientedProgramming.Lab1.Entities.Environments;
using Itmo.ObjectOrientedProgramming.Lab1.Entities.Flights;

namespace Itmo.ObjectOrientedProgramming.Lab1.Entities.ImpulseEngines;

public class ImpulseEngineClassC : ImpulseEngineBase
{
    public ImpulseEngineClassC(double speed, double fuelConsumption, double startFuel)
        : base(fuelConsumption, startFuel)
    {
        Speed = speed > 0 ? speed : throw new ArgumentException("Speed must be positive", nameof(speed));
    }

    private double Speed { get; }

    public override FlightReport Move(EnvironmentBase environment) => environment is NeutrinoNebulae
        ? new FlightReport(FlightResult.ImpassableEnvironment)
        : base.Move(environment);

    protected override double GetSpentTime(double distance) => distance / Speed;
}