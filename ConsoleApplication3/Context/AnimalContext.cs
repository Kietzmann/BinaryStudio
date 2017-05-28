using System;
using System.Collections.Generic;
using System.Linq;
using ConsoleApplication3.Entity;

namespace ConsoleApplication3.Context
{
    public sealed class AnimalContext /*: IDisposable*/
    {
        private static volatile AnimalContext instance;
        private static readonly Lazy<AnimalContext> lazy = new Lazy<AnimalContext>(() => new AnimalContext());
        private readonly Dictionary<string, Animal> animals;

        private AnimalContext()
        {
            animals = new Dictionary<string, Animal>();
        }

        public static AnimalContext Instance => lazy.Value;

        public void Add(Animal animal)
        {
            if (animal != null)
                animals[animal.Alias] = animal;
        }

        public Animal Find(string name)
        {
            Animal result = null;
            if (animals.ContainsKey(name))
                result = animals[name];
            return result;
        }

        public IEnumerable<Animal> GetAnimals()
        {
            return animals.Values;
        }

        public void Remove(Animal animal)
        {
            animals.Remove(animal.Alias);
        }

        public bool IsAllAnimalsDead()
        {
            return animals.Values.All(animal => animal.IsDead()) && animals.Count != 0;
        }
    }
}