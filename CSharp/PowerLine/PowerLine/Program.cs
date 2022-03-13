using System;
using System.Collections.Generic;

namespace PowerLine
{
    internal class Program
    {
        ///<summary>
        /// Общий класс для создания коллекций спец. сущностей, которые не должны повторятся.
        /// </summary>
        internal sealed class BaseParamsCollector
        {
            public List<int> IdList;
            public List<string> NameList;

            public BaseParamsCollector()
            {
                IdList = new List<int>();
                NameList = new List<string>();
                IdList.Add(0);
                NameList.Add("Нулевое значение");
            }
        }
        ///<summary>
        /// Общий класс для создания спец. сущностей, которые не должны повторятся.
        /// По идее - этим классом можно и пассажиров создавать, и грузы и т.п.
        /// </summary>
        internal sealed class BaseItem
        {
            private int _id;
            private string _name;
            private BaseParamsCollector _baseParamsCollector;

            public int Id
            {
                get { return _id; }
                set
                {
                    if (!_baseParamsCollector.IdList.Exists(v => v == value))
                    {
                        _id = value;
                        _baseParamsCollector.IdList.Add(value);
                    }
                    else
                    {
                        throw new Exception("Такое id уже есть");
                    }
                }
            }
            public string Name
            {
                get { return _name; }
                set
                {
                    if (!_baseParamsCollector.NameList.Exists(v => v == value))
                    {
                        _name = value;
                        _baseParamsCollector.NameList.Add(value);
                    }
                    else
                    {
                        throw new Exception("Такое имя уже есть");
                    }
                }
            }

            public BaseItem(BaseParamsCollector baseParam)
            {
                _baseParamsCollector = baseParam;
            }
        }
        ///<summary>
        /// Общий класс для автомобиля.
        /// </summary>
        internal class CarEntity
        {
            private BaseItem _carType;
            private int _averageFuelConsumption;
            private int _totalFuelValue;
            private int _speed;

            public int AverageFuelConsumption
            {
                get { return _averageFuelConsumption;}
                set { _averageFuelConsumption = value;}
            }
            public int TotalFuelValue
            {
                get { return _totalFuelValue;}
                set { _totalFuelValue = value;}
            }
            public int Speed
            {
                get { return _speed;}
                set { _speed = value;}
            }

            public BaseItem CarType
            {
                get { return _carType; }
                set
                {
                    if (value.Id > 0 && value.Name != String.Empty)
                    {
                        _carType = value;
                    }
                    else
                    {
                        throw new Exception("Обязательно что-то введи");
                    }
                }
            }
            public CarEntity(BaseItem carType, int fuelCons, int totalFuel, int speed)
            {
                _carType = carType;
                AverageFuelConsumption = fuelCons;
                TotalFuelValue = totalFuel;
                Speed = speed;
            }

            public int DistanceTotalFuel()
            {
                return TotalFuelValue * AverageFuelConsumption;
            }

            public int DistanceCurrentFuel(int currentFuel)
            {
                return currentFuel * AverageFuelConsumption;
            }
        }
        ///<summary>
        /// Класс для легкового автомобиля.
        /// </summary>
        internal sealed class PassengerCar : CarEntity
        {
            private int _maxPassengers;
            private int _currentPassengers;
            private static readonly double _percent = 0.06;
            public int MaxPassengers 
            {
                get { return _maxPassengers; } 
                set { _maxPassengers = value; }
            }
            public int CurrentPassengers
            {
                set
                {
                    if (value <= MaxPassengers)
                    {
                        _currentPassengers = value;
                    }
                    else
                    {
                        _currentPassengers = _maxPassengers;
                        Console.WriteLine($"{value - _maxPassengers} чел. - ждут другой автомобиль");
                    }
                }
                get { return _currentPassengers; }
            }
            public PassengerCar(BaseItem carType, int fuelCons, int totalFuel, int speed, int maxPassengers) : base (carType, fuelCons, totalFuel, speed)
            {
                _maxPassengers = maxPassengers;
            }
            public double DistanceTotalFuelWhithPassengers()
            {
                return (this.AverageFuelConsumption * this.TotalFuelValue) * _percent * _currentPassengers;
            }
        }
        ///<summary>
        /// Класс для грузового автомобиля.
        /// </summary>
        internal sealed class TruckCar : CarEntity
        {
            private int _maxWeight;
            private int _currentWeight;
            private static readonly double _percent = 0.04;
            public int MaxWeight 
            { 
                get { return _maxWeight; }
                set { _maxWeight = value; }
            }
            public int CurrentWeght
            {
                set
                {
                    if (value <= MaxWeight)
                    {
                        _currentWeight = value;
                    }
                    else
                    {
                        _currentWeight = _maxWeight;
                        Console.WriteLine($"{value - _maxWeight} кг - ждут другой автомобиль");
                    }
                }
                get { return _currentWeight; }
            }
            public TruckCar(BaseItem carType, int fuelCons, int totalFuel, int speed, int maxWeight) : base(carType, fuelCons, totalFuel, speed)
            {
                _maxWeight = maxWeight;
            }
            public double DistanceTotalFuelWhithWeight()
            {
                return (this.AverageFuelConsumption * this.TotalFuelValue) * _percent * (_currentWeight / 200);
            }
        }

        static void Main(string[] args)
        {
            try
            {
                // Создаю базовую коллекцию для автомобилей
                BaseParamsCollector baseCarParamColl = new BaseParamsCollector();
                
                // Создаю типы автомомбилей
                BaseItem carTypeFord = new BaseItem(baseCarParamColl);
                carTypeFord.Id = 1;
                carTypeFord.Name = "Ford";

                BaseItem carTypeMaz = new BaseItem(baseCarParamColl);
                carTypeMaz.Id = 2;
                carTypeMaz.Name = "MAZ";


                // Создаю легковой автомобиль
                PassengerCar ford = new PassengerCar(carTypeFord, 8, 50, 100, 3);
                Console.WriteLine($"Дистанция на полном баке: {ford.DistanceTotalFuel()}");
                Console.WriteLine($"Дистанция на 10 литров топлива: {ford.DistanceCurrentFuel(10)}");
                int passengers = 4;
                Console.WriteLine($"Усаживаю {passengers} пассажира в {ford.CarType.Name}");
                ford.CurrentPassengers = passengers;
                Console.WriteLine($"Дистанция на полном баке при {ford.CurrentPassengers} пассажирах: {ford.DistanceTotalFuelWhithPassengers()}");


                // Создаю грузовой автомобиль
                Console.WriteLine("____________________________________");
                TruckCar maz = new TruckCar(carTypeMaz, 20, 100, 60, 1000);
                Console.WriteLine($"Дистанция на полном баке: {maz.DistanceTotalFuel()}");
                Console.WriteLine($"Дистанция на 10 литров топлива: {maz.DistanceCurrentFuel(10)}");
                int weight = 1200;
                Console.WriteLine($"Загружаю {weight} кг в {maz.CarType.Name}");
                maz.CurrentWeght = weight;
                Console.WriteLine($"Дистанция на полном баке при {maz.CurrentWeght} кг: {maz.DistanceTotalFuelWhithWeight()}");
            }
            catch (Exception ex)
            {
                // Отлов ошибок инициализации и работы. В данном примере - только на создание сущности с уже существующим id или name, а также на 
                // ошибку инициализации авто
                Console.WriteLine(ex.Message);
            }

        }
    }
}
