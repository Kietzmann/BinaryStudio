using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ConsoleApplication3.Controller;
using ConsoleApplication3.Entity;
using ConsoleApplication3.Repository;

namespace ConsoleApplication3
{
    public class ZooController : IController<Animal>
    {

        private AnimalRepository repository;

        public ZooController(AnimalRepository repository)
        {
            this.repository = repository;
        }

        public void FeedAnimal(string animalName)
        {
            var animal = repository.GetAnimal(animalName);
            if (animal != null)
            {
                animal.Feed();
            }
        }

        public void TreatAnimal(string animalName)
        {
            var animal = repository.GetAnimal(animalName);
            if (animal != null)
            {
                animal.Treat();
            }
        }

        public void AddNewAnimal(Animal animal)
        {
            repository.Create(animal);
        }

        public void RemoveAnimal(string animalName)
        {
            var animal = repository.GetAnimal(animalName);
            if (animal != null)
            {
                if (animal.IsDead())
                {
                    repository.Delete(animal);
                }
            }
        }
    }
}
