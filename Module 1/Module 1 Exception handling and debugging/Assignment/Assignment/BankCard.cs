using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment
{
    class BankCard
    {
        public string OwnerName { get; set; }
        public string Number { get; set; }
        public double BankBalance { get; set; }
        public string CVV { get; set; }
        public DateTime ExpirationDate { get; set; }
    }
}
