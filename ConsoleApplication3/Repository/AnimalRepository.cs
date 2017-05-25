using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ConsoleApplication3.Context;
using ConsoleApplication3.Entity;

namespace ConsoleApplication3.Repository
{
    public class AnimalRepository : IAnimalRepository<Animal>
    {
//        private bool disposed = false;
        private AnimalContext context;

        public AnimalRepository(AnimalContext context)
        {
            this.context = context;
        }

//        public void Dispose()
//        {
//            Dispose(true);
//            GC.SuppressFinalize(this);
//        }
//
//        protected virtual void Dispose(bool disposing)
//        {
//            if (!this.disposed)
//            {
//                if (disposing)
//                {
//                    context.Dispose();
//                }
//            }
//            this.disposed = true;
//        }

        public Animal GetAnimal(string animalName)
        {
            Animal result = null;
            if (animalName != null)
            {
                result = context.Find(animalName);
            }
            return result;
        }

        public void Delete(Animal animal)
        {
            if (animal != null)
            {
                context.Remove(animal);
            }
        }

        public void Create(Animal animal)
        {
            if (animal != null)
            {
                context.Add(animal);
            }
        }

        public List<Animal> GetAnimals()
        {
            return context.GetAnimals().ToList();
        }

        public bool IsAllZooDead()
        {
            return context.IsAllAnimalsDead();
        }
    }
}
