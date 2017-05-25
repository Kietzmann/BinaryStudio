using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ConsoleApplication3.Repository;

namespace ConsoleApplication3
{
    public class AnimalTerminator
    {
        private AnimalRepository repository;
        private Random generator;
        public AnimalTerminator(AnimalRepository repository)
        {
            this.repository = repository;
            generator = new Random();
        }

        public void Run()
        {
            var animals = repository.GetAnimals();
            int zooSize = animals.Count;
            int selectedNumber = generator.Next(0, zooSize);
            if (selectedNumber < zooSize - 1) { 
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
