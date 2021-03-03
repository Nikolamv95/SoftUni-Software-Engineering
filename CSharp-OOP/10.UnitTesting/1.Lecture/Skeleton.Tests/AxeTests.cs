using NUnit.Framework;
using System;

[TestFixture]
public class AxeTests
{
    [Test]
    [TestCase(100, 10, 20, 20)]
    [TestCase(100, 0, 10, 5)]
    [TestCase(100, 4, 10, 1)]
    public void WeponShouldLooseDurabilityAfterAttack(int dummyHealth,
                                                      int dummyExperience,
                                                      int axeAttack,
                                                      int axeDurability)

    {
        //Arrange
        Dummy dummy = new Dummy(dummyHealth, dummyExperience);
        Axe axe = new Axe(axeAttack, axeDurability);
        //Act
        axe.Attack(dummy);
        //Assert
        var expectedResult = axeDurability - 1;
        var actualResult = axe.DurabilityPoints;
        Assert.AreEqual(expectedResult, actualResult);
    }

    //AxeIsBrokenException is similar to AxeIsBrokenException2
    [Test]
    [TestCase(100, 4, 10, 0)]
    public void AxeIsBrokenException(int dummyHealth,
                                     int dummyExperience,
                                     int axeAttack,
                                     int axeDurability)
    {
        try
        {
            WeponShouldLooseDurabilityAfterAttack(dummyHealth, dummyExperience, axeAttack, axeDurability);
        }
        catch (InvalidOperationException se)
        {
            Assert.AreEqual("Axe is broken.", se.Message);
        }
    }

    [Test]
    [TestCase(100, 4, 10, 0)]
    public void AxeIsBrokenException2(int dummyHealth,
                                                      int dummyExperience,
                                                      int axeAttack,
                                                      int axeDurability)
    {
        //Arrange
        Dummy dummy = new Dummy(dummyHealth, dummyExperience);
        Axe axe = new Axe(axeAttack, axeDurability);
        //Act - Assert
        Assert.Throws<InvalidOperationException>(() => axe.Attack(dummy));
    }
}