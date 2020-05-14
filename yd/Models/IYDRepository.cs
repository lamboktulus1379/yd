using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace yd.Models
{
    interface IYDRepository
    {
        YD GetYD(int Id);
        IEnumerable<YD> GetAllYD();
        YD Add(YD yd);
        YD Update(YD ydChanges);
        YD Delete(int Id);
    }
}
