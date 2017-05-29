using System;
using System.Linq;
using ConsoleApplication3.Repository;

namespace ConsoleApplication3
{
    public class AnimalTerminator
    {
        private readonly AnimalRepository animalRepository;
        private readonly Random generator;

        public AnimalTerminator(AnimalRepository animalRepository)
        {
            this.animalRepository = animalRepository;
            generator = new Random();
        }

        public void Run()
        {
            var animals = animalRepository.GetAnimals().ToList();
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
            return animalRepository.IsAllZooDead();
        }
    }
}