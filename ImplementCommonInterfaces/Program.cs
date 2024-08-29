using System;
using System.Diagnostics;
using System.Reflection.Metadata.Ecma335;
using System.Runtime.ConstrainedExecution;
using System.Runtime.InteropServices;

class Program
{
    static void Main(string[] args)
    {
        #region Icomparable , Icomparer
        //Car[] cars =
        //{ new Car { Name = "Mercedes", MaxMph = 360, Horsepower = 750, Price = 110000 },
        //new Car { Name = "Bmw", MaxMph = 300, Horsepower = 600, Price = 90000 },
        //new Car { Name = "Porche", MaxMph = 280, Horsepower = 550, Price = 80000 }};
        //CarComparer carComparer = new CarComparer();
        //carComparer.SortBy = CarComparer.ComparerField.Horsepower;
        //Array.Sort(cars, carComparer);

        //foreach (Car car in cars)
        //{
        //    Console.WriteLine(car);
        //}
        #endregion

        #region IEquatable
        //List<Car> cars = new List<Car>()
        //{
        //new Car { Name = "Mercedes", MaxMph = 360, Horsepower = 750, Price = 110000 },
        //new Car { Name = "Bmw", MaxMph = 300, Horsepower = 600, Price = 90000 },
        //new Car { Name = "Porche", MaxMph = 280, Horsepower = 550, Price = 80000 }
        //};
        //var avto = new Car { Name = "Porche", MaxMph = 280, Horsepower = 550, Price = 80000 };   
        //Console.WriteLine(cars.Contains(avto));
        #endregion


        Car car = new Car("Mercedes",360, 750,110000 );
        Car car1 = (Car)car.Clone();
        car.Name = "Lada";
        Console.WriteLine(car1);

    }

    class Car : IComparable<Car>, IEquatable<Car>,ICloneable
    {
        public Car(string name, int maxMph, int horsepower, decimal price)
        {
            Name = name;
            MaxMph = maxMph;
            Horsepower = horsepower;
            Price = price;
        }
        public Car()
        {

        }
        public string Name { get; set; }
        public int MaxMph { get; set; }
        public int Horsepower { get; set; }
        public decimal Price { get; set; }

        public int CompareTo(Car? other)
        {
            if (other == null) throw new ArgumentException("Is null");
            return MaxMph.CompareTo(other.MaxMph);
        }
        public override string ToString()
        {
            return $" Name: {Name} --- Maksimal suret: {MaxMph} --- At gucu: {Horsepower} --- Qiymeti: {Price}";
        }

        public bool Equals(Car? other)
        {
            return Name == other.Name && MaxMph== other.MaxMph && Horsepower==other.Horsepower && Price==other.Price;
        }

        public object Clone()
        {
            var car = new Car();
            car.Name = Name;
            car.MaxMph = MaxMph;
            car.Horsepower = Horsepower;
            car.Price =Price;
            return car;
        }
    }
    class CarComparer : IComparer<Car>
    {
        public enum ComparerField
        {
            Name,
            MaxMph,
            Horsepower,
            Price
        }
        public ComparerField SortBy;
        public int Compare(Car? x, Car? y)
        {
            switch (SortBy)
            {
                case ComparerField.Name:
                    return x.Name.CompareTo(y.Name);
                case ComparerField.MaxMph:
                    return x.MaxMph.CompareTo(y.MaxMph);
                case ComparerField.Horsepower:
                    return x.Horsepower.CompareTo(y.Horsepower);
                case ComparerField.Price:
                    return x.Price.CompareTo(y.Price);
                default: throw new ArgumentException();
            }
        }
    }
}