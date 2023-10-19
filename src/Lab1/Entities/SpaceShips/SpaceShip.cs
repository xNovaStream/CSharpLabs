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
    private readonly ImpulseEngineBase _impulseEngine;
    private readonly JumpEngineBase _jumpEngine;
    private readonly Deflector _deflector;
    private readonly Armor _armor;

    public SpaceShip(
        ImpulseEngineBase impulseEngine,
        JumpEngineBase jumpEngine,
        Deflector deflector,
        Armor armor,
        bool antiNeutrinoEmitter)
    {
        _impulseEngine = impulseEngine ?? throw new ArgumentNullException(nameof(impulseEngine));
        _jumpEngine = jumpEngine ?? throw new ArgumentNullException(nameof(jumpEngine));
        _deflector = deflector ?? throw new ArgumentNullException(nameof(deflector));
        _armor = armor ?? throw new ArgumentNullException(nameof(armor));
        AntiNeutrinoEmitter = antiNeutrinoEmitter;
    }

    public bool IsDeflectorActive => _deflector?.IsActive ?? false;
    public bool IsArmorActive => _armor.IsActive;

    public bool AntiNeutrinoEmitter { get; }
    public SpaceShipState State { get; private set; } = SpaceShipState.Alive;

    public void TakeDamage(Damage damage)
    {
        ArgumentNullException.ThrowIfNull(damage);

        _deflector?.TakeDamage(damage);
        _armor.TakeDamage(damage);

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

    private FlightReport ImpulseMove(EnvironmentBase environment) => _impulseEngine.Move(environment);

    private FlightReport JumpMove(HighDensityNebulae highDensityNebulae)
    {
        FlightReport flightReport = _jumpEngine.Move(highDensityNebulae);
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