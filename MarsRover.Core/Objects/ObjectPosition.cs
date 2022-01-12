using MarsRover.Common.Enums;
using MarsRover.Core.Factories;
using MarsRover.Core.Objects.Interfaces.Base;

namespace MarsRover.Core.Objects
{
    public class ObjectPosition : IObjectPosition
    {
        public int X { get; set; }
        public int Y { get; set; }
        public Direction Direction { get; set; }

        public void Initialize(string position)
        {
            CoordinateFactory.CreateRoverPosition(position, this);
        }
    }
}
