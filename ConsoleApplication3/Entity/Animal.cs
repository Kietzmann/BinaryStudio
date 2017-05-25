using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication3 {
    public abstract class Animal {
        private const string StringSeparator = " ";
        public byte HealthPoints { get; protected set; }
        public State State { get; protected set; }
        public String Alias { get; private set; }


        protected Animal(string alias)
        {
            State = State.Sated;
            Alias = alias;
        }

        public void Treat()
        {
            if (State == State.Sick)
            {
                ++State;
            }
        }

        public void Feed()
        {
            if (State == State.Hungry)
            {
                ++State;
            }
        }

        public void ChangeState()
        {
            switch (State)
            {
                case State.Sated:
                    --State;
                    break;
                case State.Hungry:
                    --State;
                    break;
                case State.Sick:
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
                State = State.Dead;
            }
        }

        public string OnStatusChanged()
        {
            StringBuilder result = new StringBuilder();
            result.Append(GetClassName());
            result.Append(StringSeparator);
            result.Append("with");
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
            result.Append(".");
            return result.ToString();
        }

        private string GetClassName()
        {
            return GetType().ToString().Split('.').Last();
        }
    }
}
