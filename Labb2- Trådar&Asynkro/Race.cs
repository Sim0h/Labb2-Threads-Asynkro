using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Labb2__Trådar_Asynkro
{
    internal class Race
    {
        private bool raceFinished = false;

        public void StartRace(List<Car> cars)
        {
            Console.WriteLine("LET THE RACE BEGIN!");
            Console.WriteLine("Write 'Status' to see how the cars are doing!");

            Thread statusThread = new Thread(() => StatusListener(cars));
            statusThread.Start();

            List<Thread> threads = new List<Thread>();

            foreach (Car car in cars)
            {
                car.FinishedRace += OnCarFinishedRace;
                Thread thread = new Thread(car.DrivingProblems);
                threads.Add(thread);
                thread.Start();
            }

            foreach (Thread item in threads)
            {
                item.Join();
            }

        }

        private void OnCarFinishedRace(object sender, EventArgs e) 
        {
            if(!raceFinished)
            {
                Car winner = (Car)sender;
                raceFinished = true;
                Console.WriteLine($"~~~~~~The winner is {winner.Name}!~~~~~~");
            }
        }

        private void StatusListener(List<Car> cars)
        {
            while (true)
            {

                string userInput = Console.ReadLine();
                if (userInput.ToLower() == "status")
                {
                    Console.WriteLine("Current race status:");
                    foreach (Car car in cars)
                    {
                        Console.WriteLine($"{car.Name}: Distance driven: {car.Distance}, Speed: {car.Speed}");
                    }

                }

            }
        }
    }
}