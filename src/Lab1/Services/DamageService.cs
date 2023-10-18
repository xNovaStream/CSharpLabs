using System;
using System.Collections.Generic;
using Itmo.ObjectOrientedProgramming.Lab1.Entities.Obstacles;
using Itmo.ObjectOrientedProgramming.Lab1.Entities.SpaceShips;
using Itmo.ObjectOrientedProgramming.Lab1.Interfaces;

namespace Itmo.ObjectOrientedProgramming.Lab1.Services;

public static class DamageService
{
    public static void Damage(IDamageDealer damageDealer, IDamageTaker damageTaker)
    {
        ArgumentNullException.ThrowIfNull(damageDealer);
        ArgumentNullException.ThrowIfNull(damageTaker);

        if (damageDealer is SpaceWhale && damageTaker is SpaceShip { AntiNeutrinoEmitter: true }) return;

        damageTaker.TakeDamage(damageDealer.Damage);
    }

    public static void Damage(IEnumerable<IDamageDealer> damageDealers, IDamageTaker damageTaker)
    {
        ArgumentNullException.ThrowIfNull(damageDealers);
        ArgumentNullException.ThrowIfNull(damageTaker);

        foreach (IDamageDealer damageDealer in damageDealers)
        {
            Damage(damageDealer, damageTaker);
        }
    }
}