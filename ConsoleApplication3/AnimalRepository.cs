using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication3
{
    public interface IAnimalRepository<T> where T : Animal
    {
        T GetAnimal(string animalName);
        void Delete(T animal);
        void Create(T animal);
//        void Update(T animal);
    }
}
