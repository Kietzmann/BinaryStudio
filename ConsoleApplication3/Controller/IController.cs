using ConsoleApplication3.Entity;

namespace ConsoleApplication3.Controller
{
    internal interface IController<T> where T : Animal
    {
        void FeedAnimal(string animalName);
        void TreatAnimal(string animalName);
        void AddNewAnimal(T animal);
    }
}