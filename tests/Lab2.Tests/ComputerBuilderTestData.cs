using System.Collections.Generic;
using System.Numerics;
using Itmo.ObjectOrientedProgramming.Lab2.Entities.Builders;
using Itmo.ObjectOrientedProgramming.Lab2.Entities.Components;
using Itmo.ObjectOrientedProgramming.Lab2.Entities.Markets.Implementations;
using Itmo.ObjectOrientedProgramming.Lab2.Entities.Validations.Implementations;

namespace Itmo.ObjectOrientedProgramming.Lab2.Tests;

public static class ComputerBuilderTestData
{
    public static ComponentsMarket Market { get; } = new ComponentsMarket(
        new[]
        {
            new Motherboard(
                "ASUS PRIME B550M-A",
                new Socket("AM4"),
                18,
                4,
                new Chipset(new List<uint> { 3600, 3200, 3000 }, true),
                4,
                2,
                new MotherboardFormFactor("mATX"),
                new Bios("AMI", "2.53", new List<Cpu>
                {
                    new Cpu(
                        "AMD Ryzen 5 5600",
                        4400,
                        6,
                        new Socket("AM4"),
                        false,
                        new List<uint> { 3200 },
                        65,
                        65),
                }),
                false),
            new Motherboard(
                "ASUS PRIME B760M-K",
                new Socket("LGA1700"),
                18,
                4,
                new Chipset(new List<uint> { 5600, 5400, 5200, 4800 }, false),
                5,
                2,
                new MotherboardFormFactor("mATX"),
                new Bios("AMI", "3.12", new List<Cpu>
                {
                    new Cpu(
                        "Intel Core i7-10700F",
                        4800,
                        8,
                        new Socket("LGA1700"),
                        true,
                        new List<uint> { 2933 },
                        65,
                        65),
                }),
                true),
        },
        new[]
        {
            new Cpu(
                "Intel Core i7-10700F",
                4800,
                8,
                new Socket("LGA1700"),
                true,
                new List<uint> { 2933 },
                65,
                65),
            new Cpu(
                "AMD Ryzen 5 5600",
                4400,
                6,
                new Socket("AM4"),
                false,
                new List<uint> { 3200 },
                65,
                65),
        },
        new[]
        {
            new CpuCoolingSystem(
                "DeepCool CK-11508",
                new Vector3(95, 70, 95),
                new List<Socket> { new("LGA1700") },
                65),
            new CpuCoolingSystem(
                "DeepCool Fan",
                new Vector3(95, 70, 95),
                new List<Socket> { new("AM4"), new("LGA1700") },
                30),
        },
        new[]
        {
            new Ram(
                "FURY Beast RGB 16 GB",
                16,
                new List<JedecPair> { new(3200, 1.2) },
                new List<XmpProfile> { new("18-18-36-54", 1.35, 1600) },
                new RamFormFactor("DIMM"),
                4,
                65),
            new Ram(
                "FURY Beast 8 GB",
                8,
                new List<JedecPair> { new(4800, 1.1) },
                new List<XmpProfile>(),
                new RamFormFactor("DIMM"),
                5,
                65),
        },
        new[]
        {
            new VideoCard(
                "GIGABITE NVIDEA GTX 1050 TI",
                new Vector2(225, 38),
                4,
                16,
                1390,
                75),
        },
        new Drive[]
        {
            new Ssd(
                "KINGSPEC P3-1TB",
                ConnectionOption.Sata,
                1024,
                570,
                2),
            new Hdd(
                "Western Digital WD Red Plus",
                8192,
                5640,
                6),
        },
        new[]
        {
            new ComputerCase(
                "AeroCool Aero One Mini",
                new Vector2(327, 50),
                new List<MotherboardFormFactor> { new("mATX") },
                new Vector3(100, 100, 100)),
        },
        new[]
        {
            new PowerUnit(
                "Exegate ATX-1000PPX",
                1000),
            new PowerUnit(
                "Exegate LowVoltage",
                170),
        },
        new[]
        {
            new WifiAdapter(
                "Wi-Fi TP-LINK TL-WN781ND PCI Express",
                "802.11g",
                true,
                1,
                1),
        });
    public static ComputerBuilder DefaultComputerBuilder { get; } = new ComputerBuilder(
        "ASUS PRIME B760M-K",
        "Intel Core i7-10700F",
        "DeepCool CK-11508",
        new List<string> { "FURY Beast 8 GB", "FURY Beast 8 GB" },
        "KINGSPEC P3-1TB",
        "AeroCool Aero One Mini",
        "Exegate ATX-1000PPX");
    public static ComputerValidator DefaultComputerValidator { get; } = new ComputerValidator(
        new CpuValidator(),
        new CpuCoolingSystemValidator(),
        new RamValidator(),
        new VideoCardValidator(),
        new CaseValidator(),
        new PowerUnitValidator(),
        new WifiAdapterValidator(),
        new PcieSataValidator());
}