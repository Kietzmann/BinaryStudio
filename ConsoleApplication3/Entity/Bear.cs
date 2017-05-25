using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication3.Entity
{
    public class Bear : Animal
    {
        public Bear(string alias) : base(alias)
        {
            HealthPoints = (int)HealthParameter.Bear;
        }
    }
}
