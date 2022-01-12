using System;

namespace MarsRover.Common.Exceptions
{
    public class OutOfLimitException : Exception
    {
        public OutOfLimitException(int limit, int attempted, string plane)
            : base($"Out of limit on plane {plane}. (Plato's limit in the {plane} plane: {limit}, Attempted position in the X plane: {attempted})")
        {
            Limit = limit;
            Attempted = attempted;
            Plane = plane;
        }

        public int Limit { get; set; }
        public int Attempted { get; set; }
        public string Plane { get; set; }
    }
}
