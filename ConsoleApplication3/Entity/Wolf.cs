using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication3
{
    public class Wolf : Animal
    {
        public Wolf(string alias) : base(alias)
        {
            HealthPoints = (int)HealthParameter.Wolf;
        }
    }
}
