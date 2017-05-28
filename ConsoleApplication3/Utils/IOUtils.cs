using System;
using System.Linq;

namespace ConsoleApplication3
{
    internal class IOUtils
    {
        public static void Prompt(Action<string> method)
        {
            Console.WriteLine(Messages.EnterAnimalNameOutput);
            var animalName = Console.ReadLine();
            if (!string.IsNullOrWhiteSpace(animalName))
                method(animalName);
            else
                Console.WriteLine(Messages.WhitespaceNameValueWarningOutput);
        }

        public static string GetAnimalTypes()
        {
            return string.Join(" ", Enum.GetValues(typeof(AnimalType)).Cast<AnimalType>());
        }
    }
}