using static System.Console;

namespace oop
{
    interface IDriveable
    {
        string Name { get; set; }
        int VehicleSpeed { get; set; }
        int RemainingFuel { get; set; }
        void StartEngine();
        void StopEngine();
        void Gas();
        void Break();
        void TurnLeft();
        void TurnRight();
    }

    abstract class EngineVehicle
    {
        public EngineVehicle()
        {
            RemainingFuel = 0;
            VehicleSpeed = 0;
        }
        public virtual int RemainingFuel { get; set; }
        public virtual int VehicleSpeed { get; set; }
    }

    class Car : EngineVehicle, IDriveable
    {
        private int _vehicleSpeed;
        private int _remainingFuel;
        public Car(string name, int speed, int fuel)
        {
            Name = name;
            VehicleSpeed = speed;
            RemainingFuel = fuel;
        }
        public string Name { get; set; }
        public override int VehicleSpeed
        {
            get => _vehicleSpeed;
            set
            {
                if (value >= 0 && value <= 160)
                {
                    _vehicleSpeed = value;
                }
                else throw new ArgumentOutOfRangeException($"Max value 160km/h, received {value}");
            }
        }
        public override int RemainingFuel
        {
            get => _remainingFuel;
            set
            {
                if (value >= 0 && value <= 60)
                {
                    _remainingFuel = value;
                }
                else throw new ArgumentOutOfRangeException($"Max value 60 liters, received {value}");
            }
        }
        /*
        This is not very DRY, instead
        I would prefer to only make the statements in the interface,
        and pass the vehicle name as param,
        but I guess that is not the purpose of an interface
        */
        void IDriveable.StartEngine()
        {
            WriteLine($"Started {Name} car");
        }
        void IDriveable.StopEngine()
        {
            WriteLine("Stopped car");
        }
        void IDriveable.Gas()
        {
            VehicleSpeed += 20;
            RemainingFuel -= 10;
            WriteLine("Increase gas!");
        }
        void IDriveable.Break()
        {
            VehicleSpeed -= 30;
            WriteLine("Breaking the car!");
        }
        void IDriveable.TurnLeft()
        {
            WriteLine("Turning the car left");
        }
        void IDriveable.TurnRight()
        {
            WriteLine("Turning the car right");
        }

    }
    class MotorBike : EngineVehicle, IDriveable
    {
        private int _vehicleSpeed;
        private int _remainingFuel;
        public MotorBike(string name, int speed, int fuel)
        {
            Name = name;
            VehicleSpeed = speed;
            RemainingFuel = fuel;
        }
        public string Name { get; set; }
        public override int VehicleSpeed
        {
            get => _vehicleSpeed;
            set
            {
                if (value >= 0 && value <= 160)
                {
                    _vehicleSpeed = value;
                }
                else throw new ArgumentOutOfRangeException($"Max value 160km/h, received {value}");
            }
        }
        public override int RemainingFuel
        {
            get => _remainingFuel;
            set
            {
                if (value >= 0 && value <= 40)
                {
                    _remainingFuel = value;
                }
                else throw new ArgumentOutOfRangeException($"Max value 40 liters, received {value}");
            }
        }

        void IDriveable.StartEngine()
        {
            WriteLine($"Started {Name} bike");
        }
        void IDriveable.StopEngine()
        {
            WriteLine("Stopped bike");
        }
        void IDriveable.Gas()
        {
            VehicleSpeed += 20;
            RemainingFuel -= 5;
            WriteLine("Increase gas!");
        }
        void IDriveable.Break()
        {
            VehicleSpeed -= 30;
            WriteLine("Breaking the bike!");
        }
        void IDriveable.TurnLeft()
        {
            WriteLine("Turning the bike left");
        }
        void IDriveable.TurnRight()
        {
            WriteLine("Turning the bike right");
        }

    }
    class Bus : EngineVehicle, IDriveable
    {
        private int _vehicleSpeed;
        private int _remainingFuel;
        public Bus(string name, int speed, int fuel)
        {
            Name = name;
            VehicleSpeed = speed;
            RemainingFuel = fuel;
        }
        public string Name { get; set; }
        public override int VehicleSpeed
        {
            get => _vehicleSpeed;
            set
            {
                if (value >= 0 && value <= 120)
                {
                    _vehicleSpeed = value;
                }
                else throw new ArgumentOutOfRangeException($"Max value 120km/h, received {value}");
            }
        }
        public override int RemainingFuel
        {
            get => _remainingFuel;
            set
            {
                if (value >= 0 && value <= 150)
                {
                    _remainingFuel = value;
                }
                else throw new ArgumentOutOfRangeException($"Max value 150 liters, received {value}");
            }
        }

        void IDriveable.StartEngine()
        {
            WriteLine($"Started {Name} bus");
        }
        void IDriveable.StopEngine()
        {
            WriteLine("Stopped bus");
        }
        void IDriveable.Gas()
        {
            VehicleSpeed += 10;
            RemainingFuel -= 15;
            WriteLine("Increase gas!");
        }
        void IDriveable.Break()
        {
            VehicleSpeed -= 30;
            WriteLine("Breaking the bus!");
        }
        void IDriveable.TurnLeft()
        {
            WriteLine("Turning the bus left");
        }
        void IDriveable.TurnRight()
        {
            WriteLine("Turning the bus right");
        }


    }
}