using System;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ConsoleApplication3.Entity;
using ConsoleApplication3.Repository;

namespace ConsoleApplication3
{
    public class AnimalTerminator
    {
        private AnimalRepository animalRepository;
        private Random generator;
        public AnimalTerminator(Repository.AnimalRepository animalRepository)
        {
            this.animalRepository = animalRepository;
            generator = new Random();
        }

        public void Run()
        {
            var animals = animalRepository.GetAnimals();
            int zooSize = animals.Count;
            int selectedNumber = generator.Next(0, zooSize);
            if (selectedNumber < zooSize - 1) { 
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