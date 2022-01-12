using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarsRover.Common.Exceptions
{
    public class CrachException : Exception
    {
        public CrachException(int x, int y) : base($"There was an crash at the {x},{y} position.")
        {
            X = x;
            Y = y;
        }

        public int X { get; set; }
        public int Y { get; set; }
    }
}
