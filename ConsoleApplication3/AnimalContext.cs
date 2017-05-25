using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication3
{
    public class AnimalContext
    {
        private AnimalContext _instance { get; set; }
        private Dictionary<String, Animal> animals;

        private AnimalContext()
        {
            animals = new Dictionary<string, Animal>();
        }

        public AnimalContext GetInstance()
        {
            if (_instance == null)
            {
                _instance = new AnimalContext();
            }
            return _instance;
        }
    }
}
