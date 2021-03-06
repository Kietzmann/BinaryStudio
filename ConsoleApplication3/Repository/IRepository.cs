﻿using System;
using System.Collections.Generic;
using System.Linq;
using ConsoleApplication3.Entity;

namespace ConsoleApplication3.Repository
{
    public interface IRepository<T> where T : Animal
    {
        T GetAnimal(string animalName);
        void Delete(T animal);
        void Create(T animal);

        IEnumerable<T> GetAnimalsByState(Animal.AnimalState state);

        IEnumerable<IGrouping<Type, Animal>> GetAnimalsGroupedByType();

        IEnumerable<T> GetSickTigers();

        T GetAnimalByAlias<T>(string name) where T : Animal;

        IEnumerable<string> GetHungryAnimalsNames();

        double GetAverageHealthState();

        (T, T) GetAnimalsWithMaxAndMinimalHealthPoints();

        (IEnumerable<Animal>, IEnumerable<Animal>) GetWolfsAndBears<T, V>(int healthPoints)
            where V : Animal where T : Animal;

        IEnumerable<(Type, int)> GetDeathAnimalStatistics();

        IEnumerable<(Type, T)> GetMostHealthAnimals();
    }
}