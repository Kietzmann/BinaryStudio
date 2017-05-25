using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication3
{
    class IOUtils
    {
        public static void Prompt(Action<string> method)
        {
            Console.WriteLine("Enter animal name:\n");
            string animalName = Console.ReadLine();
            if (!String.IsNullOrWhiteSpace(animalName))
            {
               method(animalName);
            }
            else
            {
                Console.WriteLine("You have entered whitespace name value.");
            }
        }

        public static string GetAnimalTypes()
        {
            return String.Join(" ", Enum.GetValues(typeof (AnimalType)).Cast<AnimalType>());
        }
    }
}
