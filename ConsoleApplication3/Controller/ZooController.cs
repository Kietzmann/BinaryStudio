using ConsoleApplication3.Entity;
using ConsoleApplication3.Repository;

namespace ConsoleApplication3
{
    public class ZooController : IController<Animal>
    {
        private readonly AnimalRepository repository;

        public ZooController(AnimalRepository repository)
        {
            this.repository = repository;
        }

        public void FeedAnimal(string animalName)
        {
            var animal = repository.GetAnimal(animalName);
            animal?.Feed();
        }

        public void TreatAnimal(string animalName)
        {
            var animal = repository.GetAnimal(animalName);
            animal?.Treat();
        }

        public void AddNewAnimal(Animal animal)
        {
            repository.Create(animal);
        }

        public void RemoveAnimal(string animalName)
        {
            var animal = repository.GetAnimal(animalName);
            if (animal?.IsDead() == true)
                repository.Delete(animal);
        }
    }
}