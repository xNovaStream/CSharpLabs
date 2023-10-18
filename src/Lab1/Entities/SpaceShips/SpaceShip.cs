using System;
using Itmo.ObjectOrientedProgramming.Lab1.Entities.Environments;
using Itmo.ObjectOrientedProgramming.Lab1.Entities.Flights;
using Itmo.ObjectOrientedProgramming.Lab1.Entities.ImpulseEngines;
using Itmo.ObjectOrientedProgramming.Lab1.Entities.JumpEngines;
using Itmo.ObjectOrientedProgramming.Lab1.Entities.Protections;
using Itmo.ObjectOrientedProgramming.Lab1.Exceptions;
using Itmo.ObjectOrientedProgramming.Lab1.Interfaces;

namespace Itmo.ObjectOrientedProgramming.Lab1.Entities.SpaceShips;

public class SpaceShip : IDamageTaker
{
    public SpaceShip(
        ImpulseEngineBase impulseEngine,
        JumpEngineBase? jumpEngine,
        Deflector? deflector,
        Armor armor,
        bool antiNeutrinoEmitter)
    {
        ImpulseEngine = impulseEngine ?? throw new ArgumentNullException(nameof(impulseEngine));
        JumpEngine = jumpEngine;
        Deflector = deflector;
        Armor = armor ?? throw new ArgumentNullException(nameof(armor));
        AntiNeutrinoEmitter = antiNeutrinoEmitter;
    }

    public bool IsDeflectorActive => Deflector?.IsActive ?? false;
    public bool IsArmorActive => Armor.IsActive;

    public bool AntiNeutrinoEmitter { get; }
    public SpaceShipState State { get; private set; } = SpaceShipState.Alive;

    private ImpulseEngineBase ImpulseEngine { get; }
    private JumpEngineBase? JumpEngine { get; }
    private Deflector? Deflector { get; }
    private Armor Armor { get; }

    public void TakeDamage(Damage damage)
    {
        ArgumentNullException.ThrowIfNull(damage);

        Deflector?.TakeDamage(damage);
        Armor.TakeDamage(damage);

        if (damage.Physic > 0)
        {
            State = SpaceShipState.Destroyed;
        }
        else if (damage.Mental)
        {
            State = SpaceShipState.DeadCrew;
        }
    }

    public FlightReport Move(EnvironmentBase environment)
    {
        ArgumentNullException.ThrowIfNull(environment);
        ThrowIfNotAlive();

        return environment is HighDensityNebulae highDensityNebulae
            ? JumpMove(highDensityNebulae)
            : ImpulseMove(environment);
    }

    private FlightReport ImpulseMove(EnvironmentBase environment) => ImpulseEngine.Move(environment);

    private FlightReport JumpMove(HighDensityNebulae highDensityNebulae)
    {
        FlightReport flightReport =
            JumpEngine?.Move(highDensityNebulae) ?? new FlightReport(FlightResult.ImpassableEnvironment);
        if (flightReport.Result == FlightResult.LostShip)
        {
            State = SpaceShipState.Lost;
        }

        return flightReport;
    }

    private void ThrowIfNotAlive()
    {
        if (State != SpaceShipState.Alive) throw new SpaceShipNotAliveException();
    }
}