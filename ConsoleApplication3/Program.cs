using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Timers;
using ConsoleApplication3.Context;
using ConsoleApplication3.Provider;
using ConsoleApplication3.Repository;

namespace ConsoleApplication3
{
    class Program
    {
        private const string IncorrectValueMessage = "You have entered incorrect value. Please try again.\n";
        private static AnimalProvider Provider { get; set; }
        private static ZooController ZooController { get; set; }
        private static AnimalRepository Repository { get; set; }

        private static AnimalContext Context { get; set; }

        private static AnimalTerminator Terminator { get; set; }

        public Program()
        {

            Context = AnimalContext.Instance;
            Repository = new AnimalRepository(Context);
            ZooController = new ZooController(Repository);
            Provider = new AnimalProvider();
            Terminator = new AnimalTerminator(Repository);
        }

        static void Main(string[] args)
        {
            Program program = new Program();
            
            var timer = new Timer();
            timer.Interval = 5000;
            timer.Elapsed += (sender, eventArgs) =>
            {
                Terminator.Run();
                if (Terminator.IsAllZooDead())
                {
                    Console.WriteLine("All zoo is dead.");
                    
                    System.Environment.Exit(1);
                }
            };
            timer.Start();
            program.start();


//               ZooController controller = new ZooController();
//               controller.Changed += controller_Changed;
//            Tiger tiger = AbstractAnimalFactory.GetAnimal<Tiger>("Tigr");
//            Console.WriteLine(tiger.OnStatusChanged());
//            Console.ReadKey();
        }

        private static void Callback(object state)
        {
            
        }

        public void start()
        {
            bool proceed = true;
            while (proceed)
            {
                Console.WriteLine("Press 1 to add animal, 2 to feed animal, 3 to treat animal, 4 to kill animal.\nPress q to quit.\n");
                string input = Console.ReadLine();
                int decision;
                if (Int32.TryParse(input, out decision))
                {
                    switch (decision)
                    {
                        case 1: 
                            AddAnimal();
                            break;
                        case 2:
                            FeedAnimal();
                            break;
                        case 3:
                            TreatAnimal();
                            break;
                        case 4:
                            RemoveAnimal();
                            break;
                        default:
                            Console.WriteLine(IncorrectValueMessage);
                            break;
                    }
                }
                else if (input.Trim().ToLower() == "q")
                {
                    Console.WriteLine("Bye.");
                    Console.ReadKey();
                    proceed = false;
                }
                else
                {
                    Console.WriteLine(IncorrectValueMessage);
                }
            }
        }

        static void controller_Changed(object sender, EventArgs e)
        {
            Console.WriteLine();
            throw new NotImplementedException();
        }

        public void AddAnimal()
        {
            Console.WriteLine("Available animal types:");
            Console.WriteLine(Utils.GetAnimalTypes());
            Console.WriteLine("Enter animal type: \n");
            string animalType = Console.ReadLine();
            if (!string.IsNullOrEmpty(animalType))
            {
                Console.WriteLine("Enter animal name: \n");
                string animalName = Console.ReadLine();
                if (!string.IsNullOrEmpty(animalName)) { 
                    try
                    {
                        var animal = Provider.GetAnimal(animalName, animalType);
                        ZooController.AddNewAnimal(animal);
                    }
                    catch (ArgumentException e)
                    {
                        Console.WriteLine("You have entered incorrect type of animal");
                    }
                }
            }
        }

        public void FeedAnimal()
        {
            Utils.Prompt(ZooController.FeedAnimal);
        }

        public void TreatAnimal()
        {
            Utils.Prompt(ZooController.TreatAnimal);
        }

        public void RemoveAnimal()
        {
            Utils.Prompt(ZooController.RemoveAnimal);
        }


    }
}
