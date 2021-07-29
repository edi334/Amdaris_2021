using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment.Classes
{
    class Buyer : Person
    {
        public Buyer(int bankBalance)
        {
            BankBalance = bankBalance;
        }
        public int BankBalance { get; set; }
        public bool TryToBuy(Car WantedCar)
        {
            if (BankBalance > WantedCar.Price)
            {
                BankBalance -= WantedCar.Price;
                return true;
            }
            return false;
        }
        public bool TryToBuy(Car FirstCar, Car SecondCar)
        {
            int totalPrice = FirstCar.Price + SecondCar.Price;
            if (BankBalance > totalPrice)
            {
                BankBalance -= totalPrice;
                return true;
            }
            return false;
        }
        public bool TryToBuy(params Car[] Cars)
        {
            int totalPrice = 0;
            foreach (Car c in Cars)
            {
                totalPrice += c.Price;
            }
            if (BankBalance > totalPrice)
            {
                BankBalance -= totalPrice;
                return true;
            }
            return false;
        }
        public override string ToString()
        {
            return $"{AddresingFormula} has {BankBalance} in the bank!";
        }
        public override void Speak()
        {
            Console.WriteLine($"Hello, I am {AddresingFormula} and I am a buyer!");
        }
        public void Speak(Car car)
        {
            Console.WriteLine($"Hello, I am {AddresingFormula} and I want to buy a {car.Brand} {car.Name}!");
        }
    }
}
