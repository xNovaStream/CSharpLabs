using System.Collections.Generic;

namespace Itmo.ObjectOrientedProgramming.Lab1.Interfaces.Services;

public interface IDamageService
{
    public void Damage(IDamageDealer damageDealer, IDamageTaker damageTaker);
    public void Damage(IEnumerable<IDamageDealer> damageDealers, IDamageTaker damageTaker);
}