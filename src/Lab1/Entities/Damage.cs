namespace Itmo.ObjectOrientedProgramming.Lab1.Entities;

public class Damage
{
    public Damage(uint physic = 0, bool mental = false)
    {
        Physic = physic;
        Mental = mental;
    }

    public uint Physic { get; private set; }
    public bool Mental { get; private set; }

    public void DecreasePhysic(uint delta)
    {
        if (delta > Physic)
        {
            Physic = 0;
        }
        else
        {
            Physic -= delta;
        }
    }

    public void DecreaseMental()
    {
        Mental = false;
    }
}