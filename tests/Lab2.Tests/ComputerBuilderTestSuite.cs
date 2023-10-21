using System.Collections.Generic;
using System.Numerics;
using Itmo.ObjectOrientedProgramming.Lab2.Entities;
using Itmo.ObjectOrientedProgramming.Lab2.Entities.Builders;
using Itmo.ObjectOrientedProgramming.Lab2.Entities.Components;
using Itmo.ObjectOrientedProgramming.Lab2.Entities.Markets;
using Itmo.ObjectOrientedProgramming.Lab2.Entities.Services;
using Itmo.ObjectOrientedProgramming.Lab2.Entities.Validations;
using Xunit;

namespace Itmo.ObjectOrientedProgramming.Lab2.Tests;

public class ComputerBuilderTestSuite
{
    private static readonly ComponentsMarket Market = new ComponentsMarket(
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
                new List<XmpProfile> { },
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

    [Fact]
    public void ValidTest()
    {
        // arrange
        var validationService = new ComputerValidationService();
        var computerBuilder = new ComputerBuilder(
            "ASUS PRIME B760M-K",
            "Intel Core i7-10700F",
            "DeepCool CK-11508",
            new List<string> { "FURY Beast 8 GB", "FURY Beast 8 GB" },
            "KINGSPEC P3-1TB",
            "AeroCool Aero One Mini",
            "Exegate ATX-1000PPX");

        // act
        Computer? computer = computerBuilder.TryBuild(Market, validationService, out ValidationReport validationReport);

        // assert
        Assert.NotNull(computer);
        Assert.True(validationReport.IsValid);
        Assert.True(validationReport.HaveWarranty);
        Assert.Empty(validationReport.Descriptions);
    }

    [Fact]
    public void LowVoltageTest()
    {
        // arrange
        var validationService = new ComputerValidationService();
        var computerBuilder = new ComputerBuilder(
            "ASUS PRIME B760M-K",
            "Intel Core i7-10700F",
            "DeepCool CK-11508",
            new List<string> { "FURY Beast 8 GB", "FURY Beast 8 GB" },
            "KINGSPEC P3-1TB",
            "AeroCool Aero One Mini",
            "Exegate LowVoltage");

        // act
        Computer? computer = computerBuilder.TryBuild(Market, validationService, out ValidationReport validationReport);

        // assert
        Assert.NotNull(computer);
        Assert.True(validationReport.IsValid);
        Assert.True(validationReport.HaveWarranty);
        Assert.Single(validationReport.Descriptions);
        Assert.Contains("Warning: peak load less, then required", validationReport.Descriptions);
    }

    [Fact]
    public void WeakCoolerTest()
    {
        // arrange
        var validationService = new ComputerValidationService();
        var computerBuilder = new ComputerBuilder(
            "ASUS PRIME B760M-K",
            "Intel Core i7-10700F",
            "DeepCool Fan",
            new List<string> { "FURY Beast 8 GB", "FURY Beast 8 GB" },
            "KINGSPEC P3-1TB",
            "AeroCool Aero One Mini",
            "Exegate ATX-1000PPX",
            "GIGABITE NVIDEA GTX 1050 TI");

        // act
        Computer? computer = computerBuilder.TryBuild(Market, validationService, out ValidationReport validationReport);

        // assert
        Assert.NotNull(computer);
        Assert.True(validationReport.IsValid);
        Assert.False(validationReport.HaveWarranty);
        Assert.Single(validationReport.Descriptions);
        Assert.Contains("Warning: cpu cooling system's TDP is too low", validationReport.Descriptions);
    }

    [Fact]
    public void InvalidTest()
    {
        // arrange
        var validationService = new ComputerValidationService();
        var computerBuilder = new ComputerBuilder(
            "ASUS PRIME B760M-K",
            "Intel Core i7-10700F",
            "DeepCool CK-11508",
            new List<string> { "FURY Beast 8 GB", "FURY Beast 8 GB", "FURY Beast 8 GB" },
            "KINGSPEC P3-1TB",
            "AeroCool Aero One Mini",
            "Exegate ATX-1000PPX",
            "GIGABITE NVIDEA GTX 1050 TI");

        // act
        Computer? computer = computerBuilder.TryBuild(Market, validationService, out ValidationReport validationReport);

        // assert
        Assert.Null(computer);
        Assert.False(validationReport.IsValid);
        Assert.False(validationReport.HaveWarranty);
        Assert.Single(validationReport.Descriptions);
        Assert.Contains("Fail: too many ram plates", validationReport.Descriptions);
    }
}