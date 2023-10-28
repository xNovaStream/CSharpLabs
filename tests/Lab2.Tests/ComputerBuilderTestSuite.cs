using Itmo.ObjectOrientedProgramming.Lab2.Entities.Builders;
using Itmo.ObjectOrientedProgramming.Lab2.Entities.Validations.Implementations;
using Itmo.ObjectOrientedProgramming.Lab2.Exceptions;
using Xunit;
using static Itmo.ObjectOrientedProgramming.Lab2.Tests.ComputerBuilderTestData;

namespace Itmo.ObjectOrientedProgramming.Lab2.Tests;

public class ComputerBuilderTestSuite
{
    [Fact]
    public void ValidTest()
    {
        // arrange
        ComputerBuilder computerBuilder = DefaultComputerBuilder with { };

        // act
        computerBuilder.Build(Market, DefaultComputerValidator, out ValidationReport validationReport);

        // assert
        Assert.True(validationReport.HaveWarranty);
        Assert.Empty(validationReport.Warnings);
    }

    [Fact]
    public void LowVoltageTest()
    {
        // arrange
        ComputerBuilder computerBuilder = DefaultComputerBuilder with { PowerUnitName = "Exegate LowVoltage" };

        // act
        computerBuilder.Build(Market, DefaultComputerValidator, out ValidationReport validationReport);

        // assert
        Assert.True(validationReport.HaveWarranty);
        Assert.Single(validationReport.Warnings);
        Assert.Contains("peak load less, then required", validationReport.Warnings);
    }

    [Fact]
    public void WeakCoolerTest()
    {
        // arrange
        ComputerBuilder computerBuilder = DefaultComputerBuilder with { CpuCoolingSystemName = "DeepCool Fan" };

        // act
        computerBuilder.Build(Market, DefaultComputerValidator, out ValidationReport validationReport);

        // assert
        Assert.False(validationReport.HaveWarranty);
        Assert.Single(validationReport.Warnings);
        Assert.Contains("cpu cooling system's TDP is too low", validationReport.Warnings);
    }

    [Fact]
    public void InvalidTest()
    {
        // arrange
        ComputerBuilder computerBuilder = DefaultComputerBuilder with
        {
            WifiAdapterName = "Wi-Fi TP-LINK TL-WN781ND PCI Express",
        };

        // act
        void Action() => computerBuilder.Build(Market, DefaultComputerValidator, out ValidationReport _);

        // assert
        Assert.Throws<WifiAdapterValidationException>(Action);
    }
}