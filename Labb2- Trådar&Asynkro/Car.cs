using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace Labb2__Trådar_Asynkro
{
    internal class Car
    {
        public string Name { get; set; }
        public int Distance { get; set; }
        public int Speed { get; set; }
        public bool Finish { get; set; }
        

        public Car(string name, int speed)
        {
            Name = name;
            Distance = 0;
            Speed = speed;
            Finish = false;
        }

        public void DrivingProblems()
        {
            while(!Finish && Distance < 1000)
            {
                Thread.Sleep(1000);
                Random random = new Random();
                int issue = random.Next(1, 51);

                if (issue == 1)
                {
                    Console.WriteLine($"{Name}'s Car is out of fuel! 30 sec to fill up fuel! ");
                    Thread.Sleep(30000);
                }
                else if (issue <= 3)
                {
                    Console.WriteLine($"{Name} has a flat tier! You need to change tiers! will take 20 seconds.");
                    Thread.Sleep(20000);
                }
                else if(issue <= 8)
                {
                    Console.WriteLine($"A bird hit the window of car {Name}, need to clean it! Takes 10 seconds.");
                    Thread.Sleep(10000);
                }
                else if(issue <= 10)
                {
                    Console.WriteLine($"There is an issue with the engine on {Name} car. Slowing down with 1km/h.");
                    Speed--;
                }

                Distance += Speed;
                
            }

            if(Distance >= 1000)
            {
                Finished();
            }
        }

        public void Finished()
        {
            Finish = true;
            Console.WriteLine($"{Name} finished the race!!");
        }
    }
}
