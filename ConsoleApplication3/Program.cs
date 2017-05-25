using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ConsoleApplication3.Entity;
using ConsoleApplication3.Factory;

namespace ConsoleApplication3
{
    class Program
    {
        static void Main(string[] args)
        {
//               Controller controller = new Controller();
//               controller.Changed += controller_Changed;
            Tiger tiger = AbstractAnimalFactory.GetAnimal<Tiger>("Tigr");
            Console.WriteLine(tiger.OnStatusChanged());
            Console.ReadKey();
        }

        static void controller_Changed(object sender, EventArgs e)
        {
            Console.WriteLine();
            throw new NotImplementedException();
        }
    }
}
