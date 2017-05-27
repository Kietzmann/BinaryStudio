using System;
using System.Collections.Generic;
using System.Linq;
using ConsoleApplication3.Context;
using ConsoleApplication3.Entity;

namespace ConsoleApplication3.Repository
{
    public class AnimalRepository : IAnimalRepository<Animal>
    {
//        private bool disposed = false;
        private readonly AnimalContext context;

        public AnimalRepository(AnimalContext context)
        {
            this.context = context;
        }

//        public void Dispose()
//        {
//            Dispose(true);
//            GC.SuppressFinalize(this);
//        }
//
//        protected virtual void Dispose(bool disposing)
//        {
//            if (!this.disposed)
//            {
//                if (disposing)
//                {
//                    context.Dispose();
//                }
//            }
//            this.disposed = true;
//        }

        public Animal GetAnimal(string animalName)
        {
            Animal result = null;
            if (animalName != null)
                result = context.Find(animalName);
            return result;
        }

        public void Delete(Animal animal)
        {
            if (animal != null)
                context.Remove(animal);
        }

        public void Create(Animal animal)
        {
            if (animal != null)
                context.Add(animal);
        }

        public IEnumerable<Animal> GetAnimalsByState(Animal.AnimalState state)
        {
            var animals = GetAnimals();
            var filteredAnimals = animals.Where(animal => animal.State == state);
            return filteredAnimals;
        }

        public IEnumerable<Animal> GetAnimalsGroupedByType()
        {
            var animals = GetAnimals();
            var groupedAnimals = animals.GroupBy(animal => animal.GetType()).SelectMany(grouping => grouping.ToList());
            return groupedAnimals;
        }

        public IEnumerable<Animal> GetSickTigers()
        {
            var animals = GetAnimals();
            var sickTigers = animals.Where(animal => animal is Tiger && animal.State == Animal.AnimalState.Sick);
            return sickTigers;
        }

        public T GetAnimalByAlias<T>(string name) where T : Animal
        {
            var animals = GetAnimals();
            var selectedAnimal = animals.SingleOrDefault(animal => animal is T && animal.Alias == name);
            return (T) selectedAnimal;
        }

        public IEnumerable<string> GetHungryAnimalsNames()
        {
            var animals = GetAnimals();
            var hungryAnimals = animals.Where(animal => animal.State == Animal.AnimalState.Hungry)
                .Select(animal => animal.Alias);
            return hungryAnimals;
        }

        public double GetAverageHealthState()
        {
            var animals = GetAnimals();
            var averageHealth = animals.Select(animal => animal.HealthPoints)
                .Average(b => (int) b);
            return averageHealth;
        }

        public (Animal, Animal) GetAnimalsWithMaxAndMinimalHealthPoints()
        {
            var animals = GetAnimals();
            var result = animals.Aggregate(new
            {
                AnimalWithMinHealth = default(Animal),
                AnimalWithMaxHealth = default(Animal),
            }, (accumulator, o) => new
            {
                AnimalWithMinHealth = accumulator.AnimalWithMinHealth == null ? o : (accumulator.AnimalWithMinHealth.HealthPoints < o.HealthPoints ? accumulator.AnimalWithMinHealth : o),
                AnimalWithMaxHealth = accumulator.AnimalWithMinHealth == null ? o : (accumulator.AnimalWithMaxHealth.HealthPoints > o.HealthPoints ? accumulator.AnimalWithMaxHealth : o)
            });
            return (result.AnimalWithMaxHealth, result.AnimalWithMinHealth);
        }

        public (IEnumerable<Animal>, IEnumerable<Animal>) GetWolfsAndBears<T, V>(int healthPoints)
            where T : Animal where V : Animal
        {
            var animals = GetAnimals();
            var firstAnimalTypeResult = animals.Where(animal => animal is T && animal.HealthPoints > healthPoints);
            var secondAnimalTypeResult = animals.Where(animal => animal is V && animal.HealthPoints > healthPoints);
            return (firstAnimalTypeResult, secondAnimalTypeResult);
        }

        public IEnumerable<(Type, int)> GetDeathAnimalStatistics()
        {
            var animals = GetAnimals();
            var result = animals.FindAll(a => a.State == Animal.AnimalState.Dead).GroupBy(animal => animal.GetType()).Select(g =>
                (
                g.Key,
                g.Count()
                ));
//            result = animals.GroupBy(animal => animal.GetType()).Select(element => element);
            return result;
        }

        public IEnumerable<(Type, Animal)> GetMostHealthAnimals()
        {
            var animals = GetAnimals();
            var result = animals
                .GroupBy(a => a.GetType())
                .Select(g => new
                {
                    Type = g.Key,
                    Values = g,
                    MaxHealth = g.Max(a => a.HealthPoints)
                })
                .Select(c => (
                    c.Type,
                    c.Values.First(a => a.HealthPoints == c.MaxHealth)
                    ));

            return result;
        }

        public List<Animal> GetAnimals()
        {
            return context.GetAnimals().ToList();
        }

        public bool IsAllZooDead()
        {
            return context.IsAllAnimalsDead();
        }
    }
}