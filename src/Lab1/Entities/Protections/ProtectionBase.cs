using System;
using Itmo.ObjectOrientedProgramming.Lab1.Interfaces;

namespace Itmo.ObjectOrientedProgramming.Lab1.Entities.Protections;

public abstract class ProtectionBase : IDamageTaker
{
    protected ProtectionBase(uint hp, uint damageReduction)
    {
        Hp = hp;
        DamageReduction = damageReduction;
    }

    public bool IsActive => Hp > 0;

    private uint Hp { get; set; }
    private uint DamageReduction { get; }

    public virtual void TakeDamage(Damage damage)
    {
        ArgumentNullException.ThrowIfNull(damage);
        if (!IsActive) return;

        if (DamageReduction > damage.Physic)
        {
            damage.Physic = 0;
        }
        else if (Hp > damage.Physic - DamageReduction)
        {
            Hp -= damage.Physic - DamageReduction;
            damage.Physic = 0;
        }
        else
        {
            damage.Physic -= Hp + DamageReduction;
            Hp = 0;
        }
    }
}