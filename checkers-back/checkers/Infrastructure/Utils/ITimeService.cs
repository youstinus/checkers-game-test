using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace checkers.Infrastructure.Utils
{
    public interface ITimeService
    {
        DateTime GetCurrentTime();
    }
}
