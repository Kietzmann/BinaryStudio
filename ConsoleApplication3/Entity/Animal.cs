using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication3.Entity
{
    public abstract class Animal {
        private const string StringSeparator = " ";
        private const char Dot = '.';

        public byte HealthPoints
        {
            get { return _healthPoints; }
            protected set
            {
                _healthPoints = value;
                OnStatusChanged();
            }
        }

        protected byte _healthPoints;
        public AnimalState State
        {
            get { return _state; }
            protected set
            {
                _state = value;
                OnStatusChanged();
            }
        }

        private AnimalState _state;

        public String Alias { get; private set; }

        protected byte FullHealthPoints;

        internal enum HealthParameter
        {
            Lion = 5,
            Tiger = 4,
            Elephant = 7,
            Bear = 6,
            Wolf = 4,
            Fox = 3
        }

        public enum AnimalState { Sated = 3, Hungry = 2, Sick = 1, Dead = 0 }

        protected Animal(string alias)
        {
            if (string.IsNullOrEmpty(alias))
            {
                throw new ArgumentException("Animal alias cannot be null");
            }
            _state = AnimalState.Sated;
            Alias = alias;
        }

        public void Treat()
        {
            if (State == AnimalState.Sick)
            {
                if (HealthPoints < FullHealthPoints)
                {
                    ++HealthPoints;
                }
            }
        }

        public void Feed()
        {
            if (State == AnimalState.Hungry)
            {
                ++State;
            }
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
            {
                --HealthPoints;
            }
            else
            {
                State = AnimalState.Dead;
            }
        }

        public string OnStatusChanged()
        {
            StringBuilder result = new StringBuilder();
            result.Append(GetClassName());
            result.Append(StringSeparator);
            result.Append("with name");
            result.Append(StringSeparator);
            result.Append(Alias);
            result.Append(StringSeparator);
            result.Append("has state");
            result.Append(StringSeparator);
            result.Append(State.ToString());
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
    }
}
