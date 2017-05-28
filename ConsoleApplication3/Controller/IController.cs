using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ConsoleApplication3.Entity;

namespace ConsoleApplication3.Controller
{
    interface IController<T> where T : Animal
    {
        void FeedAnimal(string animalName);
        void TreatAnimal(string animalName);
        void AddNewAnimal(T animal);
    }
}
