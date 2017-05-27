﻿using System;
using System.Linq;
using System.Text;

namespace ConsoleApplication3.Entity
{
    public abstract class Animal
    {
        public enum AnimalState
        {
            Sated = 3,
            Hungry = 2,
            Sick = 1,
            Dead = 0
        }

        private const string StringSeparator = " ";
        private const char Dot = '.';

        protected byte _healthPoints;

        private AnimalState _state;

        protected byte FullHealthPoints;

        protected Animal(string alias)
        {
            if (string.IsNullOrEmpty(alias))
                throw new ArgumentException("Animal alias cannot be null");
            _state = AnimalState.Sated;
            Alias = alias;
        }

        public byte HealthPoints
        {
            get => _healthPoints;
            protected set
            {
                _healthPoints = value;
                OnStatusChanged();
            }
        }

        public AnimalState State
        {
            get => _state;
            protected set
            {
                _state = value;
                OnStatusChanged();
            }
        }

        public string Alias { get; }

        public void Treat()
        {
            if (State == AnimalState.Sick)
                if (HealthPoints < FullHealthPoints)
                    ++HealthPoints;
        }

        public void Feed()
        {
            if (State == AnimalState.Hungry)
                ++State;
        }

        public void DecreaseState()
        {
            switch (State)
            {
                case AnimalState.Sated:
                    --State;
                    break;
                case AnimalState.Hungry:
                    --State;
                    break;
                case AnimalState.Sick:
                    ChangeStateForSeek();
                    break;
                default:
                    break;
            }
        }

        private void ChangeStateForSeek()
        {
            if (HealthPoints > 1)
                --HealthPoints;
            else
                State = AnimalState.Dead;
        }

        public string OnStatusChanged()
        {
            var result = new StringBuilder();
            result.Append(GetClassName());
            result.Append(StringSeparator);
            result.Append("with name");
            result.Append(StringSeparator);
            result.Append(Alias);
            result.Append(StringSeparator);
            result.Append("has state");
            result.Append(StringSeparator);
            result.Append(State);
            result.Append(StringSeparator);
            result.Append("and health:");
            result.Append(StringSeparator);
            result.Append(HealthPoints);
            result.Append(Dot);
            return result.ToString();
        }

        private string GetClassName()
        {
            return GetType().ToString().Split(Dot).Last();
        }

        public bool IsDead()
        {
            return State == AnimalState.Dead;
        }

        internal enum HealthParameter
        {
            Lion = 5,
            Tiger = 4,
            Elephant = 7,
            Bear = 6,
            Wolf = 4,
            Fox = 3
        }
    }
}