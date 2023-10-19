using System;

namespace Itmo.ObjectOrientedProgramming.Lab1.Entities.Protections;

public class Deflector : ProtectionBase
{
    private readonly PhotonModifier _photonModifier;

    public Deflector(uint hp, uint damageReduction, PhotonModifier photonModifier)
        : base(hp, damageReduction)
    {
        _photonModifier = photonModifier ?? throw new ArgumentNullException(nameof(photonModifier));
    }

    public override void TakeDamage(Damage damage)
    {
        base.TakeDamage(damage);
        _photonModifier?.TakeDamage(damage);
    }
}