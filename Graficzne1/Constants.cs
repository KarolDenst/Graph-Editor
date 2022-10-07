using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;

namespace Graficzne1
{
    internal static class Constants
    {
        public static int MaxSquaredDistanceToSelect = 250;
        public static int LineToPointVariance = 10;
        public static int VertexOffset = 4;
        public static int VertexSize = 7;
        public static int ConstraintOffset = 20;
        public static int ConstraintSize = 10;
        public static int LengthEonstraint = 1;
        public static int RetryTimes = 5;
        public static double AngleConstrint = 0.5;
    }
}
