using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment
{
    public class PingerService : IPingerService
    {
        public PingerService()
        {

        }
        public PingerService(bool isUp)
        {
            _isUp = isUp;
        }
        private bool _isUp;
        public bool CheckPingerStatus()
        {
            return _isUp;
        }
    }
}
