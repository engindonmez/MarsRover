using System;
using Microsoft.Extensions.DependencyInjection;
using MarsRover.Core.Objects;
using MarsRover.Core.Objects.Interfaces;
using MarsRover.Core;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MarsRover.ConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            IServiceProvider serviceProvider = DIInitializer.Initialize();

            Console.WriteLine("Welcome to Mars Rover Simulation!");
            Console.WriteLine("Please enter plateau size to \"X Y\" format.");
            var tryAgain = false;
            do
            {
                try
                {
                    var tasks = new List<Task>();
                    var plateau = serviceProvider.GetService<IPlateau>();
                    plateau.Initialize(Console.ReadLine());
                    var addMoreRover = false;

                    do
                    {
                        Console.WriteLine("Please enter rover position to \"X Y D\" format.");
                        var roverPositionInput = Console.ReadLine();
                        Console.WriteLine("Please enter rover commands by use \"L,R,M\" chars.");
                        var roverCommandInput = Console.ReadLine();

                        var rover = serviceProvider.GetService<IRover>();
                        rover.Initialize(roverPositionInput, roverCommandInput, plateau);
                        
                        Console.WriteLine("Do you want to add more Rover?(Y)");
                        string answer = Console.ReadLine();
                        addMoreRover = !string.IsNullOrWhiteSpace(answer) && answer.ToLower() == "y";
                    } while (addMoreRover);

                    //Her rover nesnesinin farklı hızı olabileceği düşünerek Task ile yapıldı.
                    foreach (var rover in plateau.PlateauObjects)
                    {
                        tasks.Add(Task.Factory.StartNew(() =>
                        {
                            rover.Process();
                            Console.WriteLine(rover.GetOutput());
                        }));
                    }
                    Task.WaitAll(tasks.ToArray());
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                    Console.WriteLine("Do you want to try again?(Y)");
                    string tryAnswer = Console.ReadLine();
                    tryAgain = !string.IsNullOrWhiteSpace(tryAnswer) && tryAnswer.ToLower() == "y";
                }
            } while (tryAgain);
        }
    }
}
