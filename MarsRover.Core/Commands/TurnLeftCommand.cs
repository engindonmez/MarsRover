using MarsRover.Core.Commands.Interfaces;
using MarsRover.Core.Objects.Interfaces.Base;

namespace MarsRover.Core.Commands
{
    public class TurnLeftCommand : ICommand
    {

        public TurnLeftCommand()
        {
        }

        public void Process(IObjectPosition position)
        {
            switch (position.Direction)
            {
                case Common.Enums.Direction.N:
                    position.Direction = Common.Enums.Direction.W;
                    break;
                case Common.Enums.Direction.S:
                    position.Direction = Common.Enums.Direction.E;
                    break;
                case Common.Enums.Direction.W:
                    position.Direction = Common.Enums.Direction.S;
                    break;
                case Common.Enums.Direction.E:
                    position.Direction = Common.Enums.Direction.N;
                    break;
                default:
                    break;
            }
        }
    }
}
