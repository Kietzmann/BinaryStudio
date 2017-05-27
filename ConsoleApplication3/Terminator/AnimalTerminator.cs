using System;
using System.Linq;
using ConsoleApplication3.Repository;

namespace ConsoleApplication3
{
    public class AnimalTerminator
    {
        private readonly Random generator;
        private readonly AnimalRepository repository;

        public AnimalTerminator(AnimalRepository repository)
        {
            this.repository = repository;
            generator = new Random();
        }

        public void Run()
        {
            var animals = repository.GetAnimals();
            var zooSize = animals.Count;
            var selectedNumber = generator.Next(0, zooSize);
            if (selectedNumber < zooSize - 1)
            {
                var selectedAnimal = animals.ElementAt(selectedNumber);
                selectedAnimal.DecreaseState();
            }
        }

        public bool IsAllZooDead()
        {
            return repository.IsAllZooDead();
        }
    }
}