using FakeAxeAndDummy.Tests.Fakes;
using Moq;
using NUnit.Framework;

[TestFixture]
public class HeroTests
{
    //Variation with Moq and virutal implementation
    [Test]
    public void GivenHero_WhenReceiveExperience_ThenAttackedTargetDies()
    {
        Mock<ITarget> fakeTarget = new Mock<ITarget>();
        fakeTarget.Setup(x => x.GiveExperience()).Returns(20);
        fakeTarget.Setup(x => x.IsDead()).Returns(true);

        Mock<IWeapon> fakeWepon = new Mock<IWeapon>();
        Hero hero = new Hero("Mincho", fakeWepon.Object);

        hero.Attack(fakeTarget.Object);

        Assert.AreEqual(20, hero.Experience);
    }

    //Variation withouth Moq only Fake clases with simple implementation
    //[Test]
    //public void GivenHero_WhenReceiveExperience_ThenAttackedTargetDies()
    //{
    //    ITarget fakeTarget = new ITargetFake();
    //    IWeapon fakeWeapon = new IWeaponFake();
    //    Hero hero = new Hero("Mincho", fakeWeapon);
    //    hero.Attack(fakeTarget);
    //    var expectedResult = fakeTarget.GiveExperience();
    //    Assert.AreEqual(expectedResult, hero.Experience);
    //}
}