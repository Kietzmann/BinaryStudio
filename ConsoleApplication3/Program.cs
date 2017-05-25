using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ConsoleApplication3.Entity;
using ConsoleApplication3.Factory;
using ConsoleApplication3.Provider;

namespace ConsoleApplication3
{
    class Program
    {
        private static AnimalProvider Provider { get; set; }
        static void Main(string[] args)
        {
            Provider = new AnimalProvider();

            
            //console read animal name
            //console read animal type
            try
            {
                var animal = Provider.GetAnimal("Barsik", "Tiger");
                Console.WriteLine(animal.Alias);
            }
            catch (ArgumentException e)
            {
                //console write wrong name or animal type
            }


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
