using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ConsoleApplication3;

namespace ConsoleApplication3.Entity

{
    public class Elephant : Animal
    {
        public Elephant(string alias) : base(alias)
        {
            FullHealthPoints = (int)HealthParameter.Elephant;
            _healthPoints = FullHealthPoints;
        }
    }
}
