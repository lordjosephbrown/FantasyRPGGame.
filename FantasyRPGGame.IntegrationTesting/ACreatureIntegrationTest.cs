using FantasyRPGGame.Model;
using Moq;
using MyApp;
using NUnit.Framework;
using System;

namespace FantasyRPGGame.IntegrationTesting
{
    internal class FakeRandom1 : IRandom
    {
        public int Next(int num1)
        {
            return 0;
        }

        public int Next(int num1, int num2)
        {
                Random rnd = new Random();
                return rnd.Next(num1, num2);
        }
    }

    internal class FakeRandom2 : IRandom
    {
        public int Next(int num1)
        {
            Random rnd = new Random();
            return rnd.Next( 1,num1);
        }

        public int Next(int num1, int num2)
        {
            Random rnd = new Random();
            return rnd.Next(num1, num2);
        }
    }
    public class AFantasyRPGGame
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void ShouldHaveACreatureThatHas1PercentChanceOfNotTakingDamage()
        {
            var myrandom = new FakeRandom1();
            var sut = new Mock<Creature>(myrandom);
            sut.CallBase = true;
            int damage = sut.Object.TakeDamage(10);
            int HitPoints = 100 - damage;
            Assert.That(sut.Object.HitPoints, Is.EqualTo(HitPoints));
        }
        [Test]
        public void ShouldHaveACreatureThatHas99PercentChanceOfTakingDamage()
        {
            var myrandom = new FakeRandom2();
            var sut = new Mock<Creature>(myrandom);
            sut.CallBase = true;
            int damage = sut.Object.TakeDamage(10);
            int HitPoints = 100 - damage;
            Assert.That(sut.Object.HitPoints, Is.EqualTo(HitPoints));
        }
    }
}