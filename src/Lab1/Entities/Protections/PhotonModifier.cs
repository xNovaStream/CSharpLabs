using System;
using Itmo.ObjectOrientedProgramming.Lab1.Interfaces;

namespace Itmo.ObjectOrientedProgramming.Lab1.Entities.Protections;

public class PhotonModifier : IDamageTaker
{
    private uint _hp;

    public PhotonModifier(uint hp)
    {
        _hp = hp;
    }

    public void TakeDamage(Damage damage)
    {
        ArgumentNullException.ThrowIfNull(damage);

        if (_hp <= 0) return;
        _hp -= 1;
        damage.Mental = false;
    }
}