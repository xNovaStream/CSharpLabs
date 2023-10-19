using System;
using System.Collections.Generic;
using Itmo.ObjectOrientedProgramming.Lab1.Entities.Obstacles;
using Itmo.ObjectOrientedProgramming.Lab1.Entities.SpaceShips;
using Itmo.ObjectOrientedProgramming.Lab1.Interfaces;
using Itmo.ObjectOrientedProgramming.Lab1.Interfaces.Services;

namespace Itmo.ObjectOrientedProgramming.Lab1.Services;

public class DamageService : IDamageService
{
    public void Damage(IDamageDealer damageDealer, IDamageTaker damageTaker)
    {
        ArgumentNullException.ThrowIfNull(damageDealer);
        ArgumentNullException.ThrowIfNull(damageTaker);

        if (damageDealer is SpaceWhale && damageTaker is SpaceShip { AntiNeutrinoEmitter: true }) return;

        damageTaker.TakeDamage(damageDealer.Damage);
    }

    public void Damage(IEnumerable<IDamageDealer> damageDealers, IDamageTaker damageTaker)
    {
        ArgumentNullException.ThrowIfNull(damageDealers);
        ArgumentNullException.ThrowIfNull(damageTaker);

        foreach (IDamageDealer damageDealer in damageDealers)
        {
            Damage(damageDealer, damageTaker);
        }
    }
}