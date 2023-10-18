namespace Itmo.ObjectOrientedProgramming.Lab1.Entities.Protections;

public class Deflector : ProtectionBase
{
    public Deflector(uint hp, uint damageReduction, PhotonModifier? photonModifier)
        : base(hp, damageReduction)
    {
        PhotonModifier = photonModifier;
    }

    private PhotonModifier? PhotonModifier { get; }

    public override void TakeDamage(Damage damage)
    {
        base.TakeDamage(damage);
        PhotonModifier?.TakeDamage(damage);
    }
}