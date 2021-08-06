using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Assignment
{
    class Program
    {
        static void Main(string[] args)
        {
            StreamReader reader = new StreamReader("../../../Buyers.txt");
            StreamWriter logger = new StreamWriter("../../../Logs.txt");
            var payments = File.ReadAllLines("../../../Payments.txt");
            
            List<Buyer> buyers = new List<Buyer>
            {
                new Buyer(220, logger) { Name = "George Williams" },
                new Buyer(1340.5, logger) { Name = "Alex Johnson" },
                new Buyer(560.24, logger) { Name = "Alice Evans" }
            };
            
            for (string line = reader.ReadLine(); line != null; line = reader.ReadLine())
            {
                var fullLine = line.Split(" ");
                string name = fullLine.Aggregate("", (acc, word) => !int.TryParse(word, out int n) ? acc + word + " " : acc);
                var buyer = buyers.Find(b => b.Name == name.Trim());
                int nrOfPayments = Int32.Parse(fullLine[^1]);

                for (int payment = 0; payment < nrOfPayments; ++payment)
                {
                    var r = new Random();
                    var randomLine = payments[r.Next(0, payments.Length - 1)];
                    var paymentName = randomLine.Split(" ")[0];
                    var paymentCost = Double.Parse(randomLine.Split(" ")[1]);
                    Payment toPay = new Payment { Name = paymentName, Cost = paymentCost };

                    try
                    {
                        buyer.Buy(toPay);
                    }
                    catch (Exception e)
                    {
                        logger.WriteLine("Something went wrong in the payment process");
                    }
                    
                }
            }
            
            logger.Close();
        }
    }
}