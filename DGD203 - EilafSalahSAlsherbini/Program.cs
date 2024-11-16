using System;

namespace TunnelSafety
{
    public class Car
    {
        private IWheel _currentWheels;
        public float heightModifier { get; }
        public float Height => heightModifier + _currentWheels.Vehicle_Height;
        public float MaxSpeed { get; private set; }
        private float _currentSpeed;

        public Car(float baseHeight, float baseMaxSpeed, float initialFuel, IWheel initialWheels)
        {
            heightModifier = baseHeight;
            MaxSpeed = baseMaxSpeed;
            _currentWheels = initialWheels;
            AdjustForWheels();
        }

        public void ChangeWheels(IWheel newWheels)
        {
            _currentWheels = newWheels;
            MaxSpeed = 100f * _currentWheels.Speed; // having the car have a speed that relates to something more real then a multiplication system, so! Having it be mulitplied but a more realistic number is more viable! 
            Console.WriteLine("Wheels are now {newWheels.WheelType}...");
            AdjustForWheels();
        }

        private void AdjustForWheels()
        {
            Console.WriteLine($"Current wheels: {_currentWheels.WheelType}. Your vehicle's height is around {Height:F2}m tall, The most amount of speed you've gone through is {MaxSpeed:F2} km/h, wow.");
        }

        public void RoofofTunnelCheck(float Tunnel_roof_threshold)
        {
            if (Height >= 25)
            {
                if (_currentSpeed > 1.2f)
                {
                    Console.WriteLine("!!CRASH!! You rip the top off your car and the you couldn't stop in time due to your speed...");
                    _currentSpeed = 0;
                    Environment.Exit(1); //I learned this code is supposed to stop the whole program
                }
                else
                {
                    Console.WriteLine("!!WARNING!! Vehicle is too tall for the tunnel but thankfully You just stopped in the nick of time!");
                    _currentSpeed = 0;
                    Environment.Exit(1); //I learned this code is supposed to stop the whole program
                }
            }
            else
            {
                Console.WriteLine(" ");
                Console.WriteLine("You feel the darkness of the drift through as you pass the tunnel");
            }
        }

    }

    class Program
    {
        static void Main(string[] args)
        {
            const float Tunnel_roof_threshold = 25f;

            Console.WriteLine(" ");
            Console.WriteLine(" You have a wheelless car infront of you. There is a catalog of wheels around you that you can use and there is a tunnel around 25 meters high.");
            Console.WriteLine(" ");
            Console.WriteLine(" ");
            Console.WriteLine("Choose your preferred wheels - between the selection of A, B, or C");
            Console.WriteLine(" ");
            Console.WriteLine("Type 'A' for selecting 'Regular Wheel'");
            Console.WriteLine("Type 'B' for selecting 'Monster Truck Wheel'");
            Console.WriteLine("Type 'C' for selecting 'Racing Wheel'");

            IWheel selectedWheels = null;
            string input = Console.ReadLine();

            switch (input)
            {
                case "A":
                    selectedWheels = new RegularWheel();
                    break;
                case "B":
                    selectedWheels = new MonsterTruckWheel();
                    break;
                case "C":
                    selectedWheels = new RacingWheel();
                    break;
                default:
                    Console.WriteLine("Invalid choice. Defaulting to Regular Wheel.");
                    selectedWheels = new RegularWheel();
                    break;
            }

            Car car = new Car(2.5f, 120f, 50f, selectedWheels);

            car.RoofofTunnelCheck(Tunnel_roof_threshold);

            Console.WriteLine("You're driving through the tunnel. You see the peak of light and halt your car. It was a successful swap-in of wheels!");
        }
    }
}
