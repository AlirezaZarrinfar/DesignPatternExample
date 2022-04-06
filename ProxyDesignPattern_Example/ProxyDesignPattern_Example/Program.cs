using System;

namespace ProxyDesignPattern_Example
{
    class Program
    {
        static void Main(string[] args)
        {
            // Not Allow
            ICar car = new CarProxy(new Driver { Name = "Alireza", Age = 15 });
            car.Drive();
            // Allow
            ICar car2 = new CarProxy(new Driver { Name = "Alireza", Age = 19 });
            car2.Drive();
        }



        public interface ICar
        {
            public void Drive();
        }
        public class Car : ICar
        {
            public void Drive()
            {
                Console.WriteLine("Car is being driven");
            }
        }
        public class Driver
        {
            public string Name { get; set; }
            public int Age { get; set; }
        }

        //Proxy
        public class CarProxy : ICar
        {
            
            Car car = new Car();
            Driver driver;
            public CarProxy(Driver _driver)
            {
                driver = _driver;
            }
            public void Drive()
            {
                if (driver.Age < 18)
                {
                    Console.WriteLine("You are not allow to drive");
                }
                else
                {
                    car.Drive();   
                }
            }
        }


    }
}
