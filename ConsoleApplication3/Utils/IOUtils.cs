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
            Console.WriteLine(Messages.EnterAnimalNameOutput);
            string animalName = Console.ReadLine();
            if (!String.IsNullOrWhiteSpace(animalName))
            {
               method(animalName);
            }
            else
            {
                Console.WriteLine(Messages.WhitespaceNameValueWarningOutput);
            }
        }

        public static string GetAnimalTypes()
        {
            return String.Join(" ", Enum.GetValues(typeof (AnimalType)).Cast<AnimalType>());
        }
    }
}
