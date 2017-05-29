using System;
using System.Collections.Generic;
using System.Linq;
using ConsoleApplication3.Context;
using ConsoleApplication3.Entity;
using ConsoleApplication3.Repository;
using NUnit.Framework;

namespace Test
{
    [TestFixture]
    public class AnimalProviderTest
    {
        [SetUp]
        public void TestInitialize()
        {
            lion = new Lion("L");
            tiger = new Tiger("T");
            bear = new Bear("B");
            wolf = new Wolf("W");
            elephant = new Elephant("E");
            fox = new Fox("F");
            context = AnimalContext.Instance;
            repository = new AnimalRepository(context);
            repository.Create(tiger);
            repository.Create(lion);
            repository.Create(bear);
            repository.Create(elephant);
            repository.Create(fox);
            repository.Create(wolf);
        }

        [TearDown]
        public void TestTearDown()
        {
            repository = null;
            context.Clean();
        }

        private AnimalContext context;
        private AnimalRepository repository;
        private Lion lion;
        private Tiger tiger;
        private Bear bear;
        private Elephant elephant;
        private Fox fox;
        private Wolf wolf;

        [Test]
        public void TestGetAnimalByState()
        {
            wolf.DecreaseState();
            Assert.AreEqual(wolf, repository.GetAnimalsByState(Animal.AnimalState.Hungry).First());
            wolf.DecreaseState();
            Assert.AreEqual(wolf, repository.GetAnimalsByState(Animal.AnimalState.Sick).First());
            var satedAnimals = 5;
            Assert.AreEqual(satedAnimals, repository.GetAnimalsByState(Animal.AnimalState.Sated).Count());
        }

        [Test]
        public void TestGetAnimalsByAlias()
        {
            Assert.AreEqual(elephant, repository.GetAnimalByAlias<Elephant>("E"));
        }

        [Test]
        public void TestGetAnimalsWithMaxAndMinimalHealthPoints()
        {
            Assert.AreEqual((elephant as Animal, fox as Animal), repository.GetAnimalsWithMaxAndMinimalHealthPoints());
        }

        [Test]
        public void TestGetAverageHealthState()
        {
            var averageHealthState = repository.GetAnimals().Average(animal => animal.HealthPoints);
            Assert.AreEqual(averageHealthState, repository.GetAverageHealthState());
        }

        [Test]
        public void TestGetDeathAnimalStatistics()
        {
            fox.DecreaseState();
            fox.DecreaseState();
            fox.DecreaseState();
            fox.DecreaseState();
            fox.DecreaseState();
            fox.DecreaseState();
            wolf.DecreaseState();
            wolf.DecreaseState();
            wolf.DecreaseState();
            wolf.DecreaseState();
            wolf.DecreaseState();
            wolf.DecreaseState();
            wolf.DecreaseState();
            var result = repository.GetDeathAnimalStatistics();
            Assert.AreEqual((typeof(Fox), 1), result.First());
            Assert.AreEqual((typeof(Wolf), 1), result.Last());
        }

        [Test]
        public void TestGetHungryAnimalNames()
        {
            tiger.DecreaseState();
            elephant.DecreaseState();
            fox.DecreaseState();
            CollectionAssert.AreEquivalent(new List<string> {tiger.Alias, elephant.Alias, fox.Alias},
                repository.GetHungryAnimalsNames());
        }

        [Test]
        public void TestGetMostHealthAnimals()
        {
            Animal healthLion = new Lion("Health Lion");
            Animal healthTiger = new Tiger("Health Tiger");
            Animal healthBear = new Bear("Health Bear");
            Animal healthWolf = new Wolf("Healt Wolf");
            Animal healthElephant = new Elephant("Healt Elephant");
            Animal healthFox = new Fox("Health Fox");
            repository.Create(healthFox);
            repository.Create(healthBear);
            repository.Create(healthElephant);
            repository.Create(healthLion);
            repository.Create(healthTiger);
            repository.Create(healthWolf);
            for (var i = 0; i < 4; i++)
            {
                lion.DecreaseState();
                tiger.DecreaseState();
                bear.DecreaseState();
                wolf.DecreaseState();
                elephant.DecreaseState();
                fox.DecreaseState();
            }
            CollectionAssert.AreEquivalent(new List<(Type, Animal)>
                {
                    (typeof(Tiger), healthTiger),
                    (typeof(Lion), healthLion),
                    (typeof(Bear), healthBear),
                    (typeof(Elephant), healthElephant),
                    (typeof(Fox), healthFox),
                    (typeof(Wolf), healthWolf)
                },
                repository.GetMostHealthAnimals());
        }

        [Test]
        public void TestGetSickTigers()
        {
            Animal tiger = new Tiger("Sick Tiger");
            tiger.DecreaseState();
            tiger.DecreaseState();
            repository.Create(tiger);
            Assert.AreEqual(tiger, repository.GetSickTigers().First());
            this.tiger.DecreaseState();
            this.tiger.DecreaseState();
            CollectionAssert.AreEquivalent(new List<Animal> {tiger, this.tiger}, repository.GetSickTigers());
        }

        [Test]
        public void TestGetWolfsAndBears()
        {
            var result = repository.GetWolfsAndBears<Wolf, Bear>(3);
            CollectionAssert.AreEquivalent(new List<Animal> {wolf}, result.Item1);
            CollectionAssert.AreEquivalent(new List<Animal> {bear}, result.Item2);
        }
    }
}