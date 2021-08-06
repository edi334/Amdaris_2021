using System;
using System.IO;

namespace Assignment
{
    public class Buyer
    {
        public Buyer(double bankBalance, StreamWriter logger)
        {
            _bankBalance = bankBalance;
            _logger = logger;
        }
        public string Name { get; set; }
        private double _bankBalance;
        private readonly StreamWriter _logger;
        public void Buy(Payment payment)
        {
            if (payment.Cost > _bankBalance)
            {
                string message = "Payment was not successful! Not enough bank balance.";
                _logger.WriteLine(message);
                return;
            }

            _bankBalance -= payment.Cost;
            _logger.WriteLine($"{Name} successfully bought {payment.Name}. Bank balance is {_bankBalance}.");
        }
    }
}