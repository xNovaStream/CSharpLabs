using System;
using Itmo.ObjectOrientedProgramming.Lab1.Interfaces;

namespace Itmo.ObjectOrientedProgramming.Lab1.Entities.Protections;

public class PhotonModifier : IDamageTaker
{
    public PhotonModifier(uint hp)
    {
        Hp = hp;
    }

    private uint Hp { get; set; }

    public void TakeDamage(Damage damage)
    {
        ArgumentNullException.ThrowIfNull(damage);

        if (Hp <= 0) return;
        Hp -= 1;
        damage.Mental = false;
    }
}