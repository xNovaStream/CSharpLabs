using System.Collections.Generic;
using System.Numerics;
using Itmo.ObjectOrientedProgramming.Lab2.Entities.Builders;
using Itmo.ObjectOrientedProgramming.Lab2.Entities.Components;
using Itmo.ObjectOrientedProgramming.Lab2.Entities.Markets;
using Itmo.ObjectOrientedProgramming.Lab2.Entities.Validations;
using Itmo.ObjectOrientedProgramming.Lab2.Exceptions;
using Xunit;

namespace Itmo.ObjectOrientedProgramming.Lab2.Tests;

public class ComputerBuilderTestSuite
{
    private readonly ComponentsMarket _market = new ComponentsMarket(
        new[]
        {
            new Motherboard(
                "ASUS PRIME B550M-A",
                "AM4",
                18,
                4,
                new Chipset(new List<uint> { 3600, 3200, 3000 }, true),
                4,
                2,
                "mATX",
                new Bios("AMI", "2.53", new List<string>
                {
                    "AMD Ryzen 5 5600",
                }),
                false),
            new Motherboard(
                "ASUS PRIME B760M-K",
                "LGA1700",
                18,
                4,
                new Chipset(new List<uint> { 5600, 5400, 5200, 4800 }, false),
                5,
                2,
                "mATX",
                new Bios("AMI", "3.12", new List<string>
                {
                    "Intel Core i7-10700F",
                }),
                true),
        },
        new[]
        {
            new Cpu(
                "Intel Core i7-10700F",
                4800,
                8,
                "LGA1700",
                true,
                new List<uint> { 2933 },
                65,
                65),
            new Cpu(
                "AMD Ryzen 5 5600",
                4400,
                6,
                "AM4",
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
                new List<string> { "LGA1700" },
                65),
            new CpuCoolingSystem(
                "DeepCool Fan",
                new Vector3(95, 70, 95),
                new List<string> { "AM4", "LGA1700" },
                30),
        },
        new[]
        {
            new Ram(
                "FURY Beast RGB 16 GB",
                16,
                new Dictionary<uint, double> { { 3200, 1.2 } },
                new List<XmpProfile> { new XmpProfile("18-18-36-54", 1.35, 1600) },
                "DIMM",
                4,
                65),
            new Ram(
                "FURY Beast 8 GB",
                8,
                new Dictionary<uint, double> { { 4800, 1.1 } },
                new List<XmpProfile>(),
                "DIMM",
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
                new List<string> { "mATX" },
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

    private readonly ComputerBuilder _defaultComputerBuilder = new ComputerBuilder(
        "ASUS PRIME B760M-K",
        "Intel Core i7-10700F",
        "DeepCool CK-11508",
        new List<string> { "FURY Beast 8 GB", "FURY Beast 8 GB" },
        "KINGSPEC P3-1TB",
        "AeroCool Aero One Mini",
        "Exegate ATX-1000PPX");

    private readonly ComputerValidator _computerValidator = new ComputerValidator(
        new CpuValidator(),
        new CpuCoolingSystemValidator(),
        new RamValidator(),
        new VideoCardValidator(),
        new CaseValidator(),
        new PowerUnitValidator(),
        new WifiAdapterValidator(),
        new PcieSataValidator());

    [Fact]
    public void ValidTest()
    {
        // arrange
        ComputerBuilder computerBuilder = _defaultComputerBuilder with { };

        // act
        computerBuilder.Build(_market, _computerValidator, out ValidationReport validationReport);

        // assert
        Assert.True(validationReport.HaveWarranty);
        Assert.Empty(validationReport.Warnings);
    }

    [Fact]
    public void LowVoltageTest()
    {
        // arrange
        ComputerBuilder computerBuilder = _defaultComputerBuilder with { PowerUnitName = "Exegate LowVoltage" };

        // act
        computerBuilder.Build(_market, _computerValidator, out ValidationReport validationReport);

        // assert
        Assert.True(validationReport.HaveWarranty);
        Assert.Single(validationReport.Warnings);
        Assert.Contains("peak load less, then required", validationReport.Warnings);
    }

    [Fact]
    public void WeakCoolerTest()
    {
        // arrange
        ComputerBuilder computerBuilder = _defaultComputerBuilder with { CpuCoolingSystemName = "DeepCool Fan" };

        // act
        computerBuilder.Build(_market, _computerValidator, out ValidationReport validationReport);

        // assert
        Assert.False(validationReport.HaveWarranty);
        Assert.Single(validationReport.Warnings);
        Assert.Contains("cpu cooling system's TDP is too low", validationReport.Warnings);
    }

    [Fact]
    public void InvalidTest()
    {
        // arrange
        ComputerBuilder computerBuilder = _defaultComputerBuilder with
        {
            WifiAdapterName = "Wi-Fi TP-LINK TL-WN781ND PCI Express",
        };

        // act
        void Action() => computerBuilder.Build(_market, _computerValidator, out ValidationReport _);

        // assert
        Assert.Throws<WifiAdapterValidationException>(Action);
    }
}