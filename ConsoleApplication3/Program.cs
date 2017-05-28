using System;
using System.Timers;
using ConsoleApplication3.Context;
using ConsoleApplication3.Provider;
using ConsoleApplication3.Repository;

namespace ConsoleApplication3
{
    internal class Program
    {
        public Program()
        {
            Context = AnimalContext.Instance;
            Repository = new AnimalRepository(Context);
            ZooController = new ZooController(Repository);
            Provider = new AnimalProvider();
            Terminator = new AnimalTerminator(Repository);
        }

        private static AnimalProvider Provider { get; set; }
        private static ZooController ZooController { get; set; }
        private static AnimalRepository Repository { get; set; }

        private static AnimalContext Context { get; set; }

        private static AnimalTerminator Terminator { get; set; }

        private static void Main(string[] args)
        {
            var program = new Program();

            var timer = new Timer {Interval = 5000};
            timer.Elapsed += (sender, eventArgs) =>
            {
                Terminator.Run();
                if (Terminator.IsAllZooDead())
                {
                    Console.WriteLine(Messages.AllZooDeadOutput);
                    Environment.Exit(1);
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
            var proceed = true;
            while (proceed)
            {
                Console.WriteLine(Messages.GreetingOutput);
                var input = Console.ReadLine();
                int decision;
                if (int.TryParse(input, out decision))
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

        private static void controller_Changed(object sender, EventArgs e)
        {
            Console.WriteLine();
            throw new NotImplementedException();
        }

        public void AddAnimal()
        {
            Console.WriteLine(Messages.AvailableAnimalTypesOutput);
            Console.WriteLine(IOUtils.GetAnimalTypes());
            Console.WriteLine(Messages.EnterAnimalTypeOutput);
            var animalType = Console.ReadLine();
            if (!string.IsNullOrEmpty(animalType))
            {
                Console.WriteLine(Messages.EnterAnimalNameOutput);
                var animalName = Console.ReadLine();
                if (!string.IsNullOrEmpty(animalName))
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