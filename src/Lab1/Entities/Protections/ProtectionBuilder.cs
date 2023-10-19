namespace Itmo.ObjectOrientedProgramming.Lab1.Entities.Protections;

public static class ProtectionBuilder
{
    public static PhotonModifier CreateNullPhotonModifier() => new PhotonModifier(0);
    public static PhotonModifier CreatePhotonModifier() => new PhotonModifier(3);

    public static Deflector CreateNullDeflector() =>
        new Deflector(0, 0, CreateNullPhotonModifier());
    public static Deflector CreateDeflectorClassOne(bool isPhoton = false) =>
        new Deflector(10, 0, isPhoton ? CreatePhotonModifier() : CreateNullPhotonModifier());
    public static Deflector CreateDeflectorClassTwo(bool isPhoton = false) =>
        new Deflector(25, 2, isPhoton ? CreatePhotonModifier() : CreateNullPhotonModifier());
    public static Deflector CreateDeflectorClassThree(bool isPhoton = false) =>
        new Deflector(50, 4, isPhoton ? CreatePhotonModifier() : CreateNullPhotonModifier());

    public static Armor CreateArmorClassOne() => new Armor(5, 0);
    public static Armor CreateArmorClassTwo() => new Armor(15, 2);
    public static Armor CreateArmorClassThree() => new Armor(25, 4);
}