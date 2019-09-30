using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GD3100Debugger
{
    public class GD3100RegDefine
    {
        public enum Gd3100_RegAddr : int
        {
            Mode1 = 0,
            Mode2 = 1,
            Config1 = 2,
            Config2 = 3,
            Config3 = 4,
            Config4 = 5,
            Config5 = 6,
            Config6 = 7,
            OT_TH   = 8,
            OTW_TH  = 9,
            Status1 = 10,
            Mask1   = 11,
            Status2 = 12,
            Mask2   = 13,
            Status3 = 14,
            ReqAdc  = 16,
            ReqBist = 17,

        };
    }
}
