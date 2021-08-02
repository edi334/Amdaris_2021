using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment
{
    class AmountIsNegativeException : Exception 
    {
        public AmountIsNegativeException()
        {

        }
        public AmountIsNegativeException(string message) : base(message)
        {

        }
        public AmountIsNegativeException(string message, Exception inner) : base(message, inner)
        {

        }
    }

    class AmountIsBiggerThanBankBalanceException : Exception
    {
        public AmountIsBiggerThanBankBalanceException()
        {

        }
        public AmountIsBiggerThanBankBalanceException(string message) : base(message)
        {

        }
        public AmountIsBiggerThanBankBalanceException(string message, Exception inner) : base(message, inner)
        {

        }
    }

    class InvalidCardCredentialsException : Exception
    {
        public InvalidCardCredentialsException()
        {

        }
        public InvalidCardCredentialsException(string message) : base(message)
        {

        }
        public InvalidCardCredentialsException(string message, Exception exception) : base(message, exception)
        {

        }
    }
}
