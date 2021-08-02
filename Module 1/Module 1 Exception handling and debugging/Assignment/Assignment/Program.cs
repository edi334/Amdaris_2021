using System;

namespace Assignment
{
    class Program
    {
        static void Payment(BankCard card, double amount, string name, string number, string cvv, DateTime date)
        {
            if (amount < 0)
            {
                throw new AmountIsNegativeException("Amount is negative!");
            }
            if (card.BankBalance < amount)
            {
                throw new AmountIsBiggerThanBankBalanceException("Amount is bigger that bank balance!");
            }
            if (!ValidCredentials(name, number, cvv, date, card))
            {
                throw new InvalidCardCredentialsException("Credentials are invalid!");
            }
            card.BankBalance -= amount;
        }
        static bool ValidCredentials(string name, string number, string cvv, DateTime date, BankCard card)
        {
            return card.OwnerName.Equals(name) && card.Number.Equals(number) && card.CVV.Equals(cvv) && card.ExpirationDate == date;
        }
        static void AddBankCard (BankCard card, BankCard[] cards, ref int pos)
        {
            if (card == null)
            {
                throw new ArgumentNullException("Card is null!");
            }
            else
            {
                cards[pos] = card;
                pos++;
            }
        }
        static void Main(string[] args)
        {
            BankCard[] array = new BankCard[2];
            BankCard c = new BankCard
            {
                BankBalance = 220.2, 
                CVV = "249", 
                ExpirationDate = DateTime.Now.AddYears(4), 
                Number = "4501-5451-1024-2144", 
                OwnerName = "Bill Johnson" 
            };
            BankCard n = null;

            int pos = Console.Read();
            AddBankCard(c, array, ref pos);
            // if line 55 is uncommented, an ArgumentNullException will be thrown
            //AddBankCard(n, array, ref pos);
            

            double amount = 150;
            string name, number, cvv;
            name = Console.ReadLine();
            number = Console.ReadLine();
            cvv = Console.ReadLine();
            
            DateTime date = c.ExpirationDate;

            try
            {
                Payment(c, amount, name, number, cvv, date);
            }
            catch (AmountIsNegativeException e)
            {
                Console.WriteLine(e);
                throw;
            }
            catch (AmountIsBiggerThanBankBalanceException e)
            {
                Console.WriteLine(e);
                throw new AmountIsBiggerThanBankBalanceException("Amount is bigger than bank balance, but from an inner exception", e);
            }
            catch (InvalidCardCredentialsException e)
            {
                Console.WriteLine(e);
                throw;
            }
            finally
            {
                Console.WriteLine($"Bank balance is {c.BankBalance}!");
            }
        }
    }
}
