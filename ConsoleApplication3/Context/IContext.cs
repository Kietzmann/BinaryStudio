using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ConsoleApplication3.Entity;

namespace ConsoleApplication3.Context
{
    public interface IContext<T> where T : Animal
    {
        void Add(T animal);
        T Find(string name);
        IEnumerable<T> GetAnimals();
        void Remove(T animal);
    }
}
