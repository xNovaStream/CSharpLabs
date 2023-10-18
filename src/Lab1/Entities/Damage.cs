namespace Itmo.ObjectOrientedProgramming.Lab1.Entities;

public class Damage
{
    public Damage(uint physic = 0, bool mental = false)
    {
        Physic = physic;
        Mental = mental;
    }

    public uint Physic { get; set; }
    public bool Mental { get; set; }
}