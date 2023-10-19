using System;
using Itmo.ObjectOrientedProgramming.Lab1.Interfaces;

namespace Itmo.ObjectOrientedProgramming.Lab1.Entities.Protections;

public abstract class ProtectionBase : IDamageTaker
{
    private readonly uint _damageReduction;
    private uint _hp;

    protected ProtectionBase(uint hp, uint damageReduction)
    {
        _hp = hp;
        _damageReduction = damageReduction;
    }

    public bool IsActive => _hp > 0;

    public virtual void TakeDamage(Damage damage)
    {
        ArgumentNullException.ThrowIfNull(damage);
        if (!IsActive) return;

        if (_damageReduction > damage.Physic)
        {
            damage.DecreasePhysic(damage.Physic);
        }
        else if (_hp > damage.Physic - _damageReduction)
        {
            _hp -= damage.Physic - _damageReduction;
            damage.DecreasePhysic(damage.Physic);
        }
        else
        {
            damage.DecreasePhysic(_hp + _damageReduction);
            _hp = 0;
        }
    }
}