using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Timers;
using ConsoleApplication3.Context;
using ConsoleApplication3.Controller;
using ConsoleApplication3.Entity;
using ConsoleApplication3.Provider;
using ConsoleApplication3.Repository;

namespace ConsoleApplication3
{
    class Program
    {
        private static AnimalProvider Provider { get; set; }
        private static ZooController ZooController { get; set; }
        private static AnimalRepository Repository { get; set; }

        private static AnimalContext Context { get; set; }

        private static AnimalTerminator Terminator { get; set; }

        public Program()
        {

            Context = AnimalContext.Instance;
            Repository = new Repository.AnimalRepository(Context);
            ZooController = new ZooController(Repository);
            Provider = new AnimalProvider();
            Terminator = new AnimalTerminator(Repository);
        }

        static void Main(string[] args)
        {
            Program program = new Program();

            var timer = new Timer {Interval = 5000};
            timer.Elapsed += (sender, eventArgs) =>
            {
                Terminator.Run();
                if (Terminator.IsAllZooDead())
                {
                    Console.WriteLine(Messages.AllZooDeadOutput);
                    System.Environment.Exit(1);
                }
            };
            timer.Start();
            program.start();
        }

        private static void Callback(object state)
        {
            
        }

        public void start()
        {
            bool proceed = true;
            while (proceed)
            {
                Console.WriteLine(Messages.GreetingOutput);
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
                            Console.WriteLine(Messages.IncorrectValueWarningOutput);
                            break;
                    }
                }
                else if (input.Trim().ToLower() == "q")
                {
                    Console.WriteLine(Messages.ByeOutput);
                    Console.ReadKey();
                    proceed = false;
                }
                else
                {
                    Console.WriteLine(Messages.IncorrectValueWarningOutput);
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
            Console.WriteLine(Messages.AvailableAnimalTypesOutput);
            Console.WriteLine(IOUtils.GetAnimalTypes());
            Console.WriteLine(Messages.EnterAnimalTypeOutput);
            string animalType = Console.ReadLine();
            if (!string.IsNullOrEmpty(animalType))
            {
                Console.WriteLine(Messages.EnterAnimalNameOutput);
                string animalName = Console.ReadLine();
                if (!string.IsNullOrEmpty(animalName)) { 
                    try
                    {
                        var animal = Provider.GetAnimal(animalName, animalType);
                        ZooController.AddNewAnimal(animal);
                    }
                    catch (ArgumentException e)
                    {
                        Console.WriteLine(Messages.IncorrectAnimalTypeValueWarningOutput);
                    }
                }
            }
        }

        public void FeedAnimal()
        {
            IOUtils.Prompt(ZooController.FeedAnimal);
        }

        public void TreatAnimal()
        {
            IOUtils.Prompt(ZooController.TreatAnimal);
        }

        public void RemoveAnimal()
        {
            IOUtils.Prompt(ZooController.RemoveAnimal);
        }


    }
}
