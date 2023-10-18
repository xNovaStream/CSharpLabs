namespace Itmo.ObjectOrientedProgramming.Lab1.Entities.Protections;

public static class ProtectionBuilder
{
    public static PhotonModifier CreatePhotonModifier() => new PhotonModifier(3);

    public static Deflector CreateDeflectorClass1(bool isPhoton = false) =>
        new Deflector(10, 0, isPhoton ? CreatePhotonModifier() : null);

    public static Deflector CreateDeflectorClass2(bool isPhoton = false) =>
        new Deflector(25, 2, isPhoton ? CreatePhotonModifier() : null);

    public static Deflector CreateDeflectorClass3(bool isPhoton = false) =>
        new Deflector(50, 4, isPhoton ? CreatePhotonModifier() : null);

    public static Armor CreateArmorClass1() => new Armor(5, 0);
    public static Armor CreateArmorClass2() => new Armor(15, 2);
    public static Armor CreateArmorClass3() => new Armor(25, 4);
}