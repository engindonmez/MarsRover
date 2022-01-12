using MarsRover.Common.Enums;

namespace MarsRover.Core.Objects.Interfaces.Base
{
    public interface IObjectPosition
    {
        int X { get; set; }
        int Y { get; set; }
        Direction Direction { get; set; }

        void Initialize(string position);
    }
}
