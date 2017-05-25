using System;
using ConsoleApplication3.Entity;

namespace ConsoleApplication3.Provider
{
    public class AnimalProvider
    {

        /// <summary>
        /// 
        /// </summary>
        /// <param name="name"></param>
        /// <param name="typeName"></param>
        /// <exception cref="ArgumentException"></exception>
        internal Animal GetAnimal(string name, string typeName)
        {
            if (string.IsNullOrEmpty(name))
            {
                throw new ArgumentException("", "name");
            }
            try
            {
                var animalType = Type.GetType(GetStandartizedNameOfAnimalClass(typeName), true);
                return (Animal) Activator.CreateInstance(animalType, name);
            }
            catch (Exception e)
            {
                throw new ArgumentException(typeName, "typeName", e);
            }
        }

        private string GetStandartizedNameOfAnimalClass(string typeName)
        {
            var animalEntityNamespace = "ConsoleApplication3.Entity";
            var assemblyName = "ConsoleApplication3";

            return string.Format("{0}.{1},{2}", animalEntityNamespace, typeName, assemblyName);
        }
    }
}