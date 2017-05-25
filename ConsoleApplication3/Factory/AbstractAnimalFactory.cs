using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication3
{
    public class AbstractAnimalFactory 
    {
        public static T GetAnimal<T>(string name) where T : Animal
        {
            return (T) Activator.CreateInstance(typeof (T), name);
        }
    }
}
