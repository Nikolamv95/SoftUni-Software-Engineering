using NUnit.Framework;
using System;

[TestFixture]
public class DummyTests
{
    private Dummy dummy;
    private Axe axe;

    [SetUp]
    public void InitializeDummy()
    {
        Dummy dummy = new Dummy(10, 20);
    }


    [Test]
    [TestCase(100, 50, 20)]
    public void DummyLoseHealthIfAttacked(int health, int experience, int attackPoints)
    {
        //Arrange

        //Act
        this.dummy.TakeAttack(attackPoints);
        var actualResult = dummy.Health;
        var expectedResult = health - attackPoints;
        //Assert
        Assert.AreEqual(expectedResult, actualResult);
    }

    [Test]
    [TestCase(0, 50, 20)]
    [TestCase(50, 50, 20)]
    public void DeadDummyThrowsExceptionIfAttacked(int health, int experience, int attackPoints)
    {
        //Arrange
        Dummy dummy = new Dummy(health, experience);
        //Act
        bool isDead = dummy.IsDead();
        //Assert
        if (isDead)
        {
            Assert.Throws<InvalidOperationException>(() => dummy.TakeAttack(attackPoints));
        }
    }

    [Test]
    [TestCase(0, 50)]
    public void DeadDummyCanGiveXp(int health, int experience)
    {
        //Arrange
        Dummy dummy = new Dummy(health, experience);
        //Act
        int actualResult = dummy.GiveExperience();
        //Assert
        Assert.AreEqual(experience, actualResult);
    }


    [Test]
    [TestCase(10, 50)]
    public void AliveDummyCantGiveXp(int health, int experience)
    {
        //Arrange
        Dummy dummy = new Dummy(health, experience);
        //Act - Assert
        Assert.Throws<InvalidOperationException>(() => dummy.GiveExperience());
    }

}
