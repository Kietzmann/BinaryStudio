using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ConsoleApplication3.Entity;

namespace ConsoleApplication3.Context
{
    public sealed class AnimalContext /*: IDisposable*/
    {
        private static volatile AnimalContext instance;
        private static object syncRoot = new Object();
        private Dictionary<String, Animal> animals;


        private AnimalContext()
        {
            animals = new Dictionary<string, Animal>();
        }

        public static AnimalContext Instance
        {
            get
            {
                if (instance == null)
                {
                    lock (syncRoot)
                    {
                        if (instance == null)
                        {
                            instance = new AnimalContext();
                        }                       
                    }
                }
                return instance;
            }
        }

        public void Add(Animal animal)
        {
            if (animal != null)
            {
                animals[animal.Alias] = animal;
            }
        }

        public Animal Find(string name)
        {
            return animals[name];
        }

        public IEnumerable<Animal> GetAnimals()
        {
            return animals.Values;
        }

        public void Remove(Animal animal)
        {
            if (animal != null)
            {
                if (animal.Alias != null)
                {
                    animals.Remove(animal.Alias);
                }
            }
        }

//        public void Update(Animal animal)
//        {
//            if (animal != null)
//            {
//                animals.;
//                
//            }
//        }


    }


}
