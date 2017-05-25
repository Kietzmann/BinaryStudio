﻿using System;
using ConsoleApplication3.Entity;
using ConsoleApplication3.Factory;

namespace ConsoleApplication3.Provider
{
    public class AnimalProvider
    {
        public Animal GetAnimal(string name, AnimalType type)
        {
            Animal result = null;
            switch (type)
            {
                case AnimalType.Bear:
                    result = AbstractAnimalFactory.GetAnimal<Bear>(name);
                    break;
                case AnimalType.Tiger:
                    result = AbstractAnimalFactory.GetAnimal<Tiger>(name);
                    break;
                case AnimalType.Elephant:
                    result = AbstractAnimalFactory.GetAnimal<Elephant>(name);
                    break;
                case AnimalType.Fox:
                    result = AbstractAnimalFactory.GetAnimal<Fox>(name);
                    break;
                case AnimalType.Lion:
                    result = AbstractAnimalFactory.GetAnimal<Lion>(name);
                    break;
                case AnimalType.Wolf:
                    result = AbstractAnimalFactory.GetAnimal<Wolf>(name);
                    break;
                default:
                    throw new ArgumentOutOfRangeException("type", "Passed Animal type is not defined or not handled");
            }
            return result;
        }
    }
}