using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace checkers.Infrastructure.Utils
{
    public class TimeService : ITimeService
    {
        public DateTime GetCurrentTime()
        {
            return DateTime.Now;
        }
    }
}
