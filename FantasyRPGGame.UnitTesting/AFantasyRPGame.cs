using FantasyRPGGame.Model;
using Moq;
using NUnit.Framework;
using System;

namespace FantasyRPGGame.UnitTesting
{
    public class MyRandom : IRandom
    {
        public int Next(int num)
        {
            Random rnd = new Random();
            return rnd.Next(num);
        }

        public int Next(int num1, int num2)
        {
            Random rnd = new Random();
            return rnd.Next(num1,num2);
        }
    }
    public class AFantasyRPGGame
    {
        

        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void ShouldReduceCreatureHealthAfterTakingDamage()
        {
            var mock = new Mock<IRandom>();
            mock.Setup(x => x.Next(It.IsAny<int>())).Returns(5);
            DummyCreature sut = new DummyCreature(mock.Object);
            sut.TakeDamage(5);
            Assert.That(sut.HitPoints, Is.EqualTo(95));
        }
        [Test]
        public void ShouldNotReduceCreatureHealthAfterDamage()
        {
            var mock = new Mock<IRandom>();
            mock.Setup(x => x.Next(It.IsAny<int>())).Returns(0);
            DummyCreature sut = new DummyCreature(mock.Object);
            sut.TakeDamage(95);
            Assert.That(sut.HitPoints, Is.EqualTo(100));
        }

        [Test]
        public void ShouldReportRaceAsHuman()
        {
            var mock = new Mock<IRandom>();
            mock.Setup(x => x.Next(It.IsAny<int>())).Returns(0);
            var sut = new Humans(mock.Object);
            Assert.That(sut.Race, Is.EqualTo("Human"));
        }

        [Test]
        public void ShouldCheckIfHumansHave10PercentChanceOfinflictingDoubleDamage()
        {
            var mock = new Mock<IRandom>();
            mock.SetupSequence(x => x.Next(It.IsAny<int>())).Returns(5).Returns(9);
            var sut = new Humans(mock.Object);
            Assert.That(sut.CalculateDamage(), Is.EqualTo(12));
        }
        [Test]
        public void ShouldCheckIfHumansHave90PercentChanceOfNotinflictingDoubleDamage()
        {
            var mock = new Mock<IRandom>();
            mock.SetupSequence(x => x.Next(It.IsAny<int>())).Returns(5).Returns(11);
            var sut = new Humans(mock.Object);
            Assert.That(sut.CalculateDamage(), Is.EqualTo(6));
        }

        [Test]
        public void ShouldReportRaceAsDemon()
        {
            MyRandom _random = new MyRandom();
            var sut = new Demons(_random);
            Assert.That(sut.Race, Is.EqualTo("Demon"));
        }

        [Test]
        public void ShouldCheckIfDemonHas25PercentChanceOfInflictingAdditional10Damage()
        {
            var mock = new Mock<IRandom>();
            mock.SetupSequence(x => x.Next(It.IsAny<int>())).Returns(10).Returns(24);
            var sut = new Demons(mock.Object);
            Assert.That(sut.CalculateDamage(), Is.EqualTo(21));
        }

        [Test]
        public void ShouldCheckIfDemonHas75PercentChanceOfInflictingBaseDamage()
        {
            var mock = new Mock<IRandom>();
            mock.SetupSequence(x => x.Next(It.IsAny<int>())).Returns(10).Returns(26);
            var sut = new Demons(mock.Object);
            Assert.That(sut.CalculateDamage(), Is.EqualTo(11));
        }


        [Test]
        public void ShouldReportRaceAsBalrog()
        {
            MyRandom _random = new MyRandom();
            var sut = new Balrogs(_random);
            Assert.That(sut.Race, Is.EqualTo("Balrog"));
        }

        [Test]
        public void ShouldCheckIfBalrogInflictsBaseDamageTwice()
        {
            var mock = new Mock<IRandom>();
            mock.SetupSequence(x => x.Next(It.IsAny<int>())).Returns(10).Returns(26);
            var sut = new Balrogs(mock.Object);
            Assert.That(sut.CalculateDamage(), Is.EqualTo(22));
        }

        [Test]
        public void ShouldReportThatCreature1WonTheDuel()
        {
            var mock1 = new Mock<IRandom>();
            mock1.Setup(x => x.Next(It.IsAny<int>())).Returns(50);
            var creature1 = new TestCreature(mock1.Object);
            creature1.Damage = 50;
            var creature2 = new TestCreature(mock1.Object);
            creature2.Damage = 30;
            var battle = new Battle();
            battle.AddCreature(creature1);
            battle.AddCreature(creature2);
            Assert.That(battle.Due1(0, 1), Is.EqualTo(0));
        }

        [Test]
        public void ShouldReportThatCreature2WonTheDuel()
        {
            var mock1 = new Mock<IRandom>();
            mock1.Setup(x => x.Next(It.IsAny<int>())).Returns(50);
            var creature1 = new TestCreature(mock1.Object);
            creature1.Damage = 30;
            var creature2 = new TestCreature(mock1.Object);
            creature2.Damage = 50;
            var battle = new Battle();
            battle.AddCreature(creature1);
            battle.AddCreature(creature2);
            Assert.That(battle.Due1(0, 1), Is.EqualTo(1));
        }

        [Test]
        public void ShouldReportATie()
        {
            var mock1 = new Mock<IRandom>();
            mock1.Setup(x => x.Next(It.IsAny<int>())).Returns(50);
            var creature1 = new TestCreature(mock1.Object);
            creature1.Damage = 50;
            var creature2 = new TestCreature(mock1.Object);
            creature2.Damage = 50;
            var battle = new Battle();
            battle.AddCreature(creature1);
            battle.AddCreature(creature2);
            Assert.That(battle.Due1(0, 1), Is.EqualTo(-1));
        }
    }
}