﻿using System.Collections.Generic;
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