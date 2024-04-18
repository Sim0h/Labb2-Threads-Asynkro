namespace Labb2__Trådar_Asynkro
{
    internal class Program
    {
        private static readonly Mutex mutex = new Mutex();
        static void Main(string[] args)
        {
            Car car1 = new Car("Simon", 120);
            Car car2 = new Car("Noah", 120);
            Car car3 = new Car("Anas", 120);
            Car car4 = new Car("Sara", 120);
            Car car5 = new Car("Sam", 120);

            List<Car> cars = new List<Car>
            {
                car1,
                car2,
                car3,
                car4,
                car5
            };

            Race race = new Race();
            race.StartRace(cars);

           
        }
    }
}
