using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ConsoleApplication3.Entity;

namespace ConsoleApplication3.Repository
{
    public interface IAnimalRepository<T> /*: IDisposable*/ where T : Animal
    {
        T GetAnimal(string animalName);
        void Delete(T animal);
        void Create(T animal);
//        void Update(T animal);
    }
}
