using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment.Classes
{
    public sealed class Garage
    {
        private static readonly Lazy<Garage> _garage = new Lazy<Garage>(() => new Garage(), true);
        private readonly List<Car> _cars = new List<Car>();
        public static Garage Instance { get { return _garage.Value; } }
        private Garage()
        {
               
        }
        public void AddCar(Car car)
        {
            _cars.Add(car);
        }
        public void RemoveCar(Car car)
        {
            _cars.Remove(car);
        }
        public Car GetByName(string name)
        {
            return _cars.Find(c => c.Name == name);
        }
        public Car GetByDriver(string driverName)
        {
            return _cars.Find(c => c.Driver.Name == driverName);
        }
        public List<Car> GetAllFromTeam(string teamName)
        {
            return _cars.Where(c => c.Team == teamName).ToList();
        }
        public void ShowCars()
        {
            _cars.ForEach(c => Console.WriteLine(c.Name + " "));
        }
    }
}
