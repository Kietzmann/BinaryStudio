using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication3
{
    public class Lion : Animal
    {
        public Lion(string alias) : base(alias)
        {
            HealthPoints = (int)HealthParameter.Lion;
        }
    }
}
