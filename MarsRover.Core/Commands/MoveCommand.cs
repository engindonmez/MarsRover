using MarsRover.Core.Commands.Interfaces;
using MarsRover.Core.Objects.Interfaces.Base;

namespace MarsRover.Core.Commands
{
    public class MoveCommand : ICommand
    {
        public MoveCommand()
        {
        }

        public void Process(IObjectPosition position)
        {
            switch (position.Direction)
            {
                case Common.Enums.Direction.N:
                    position.Y += 1;
                    break;
                case Common.Enums.Direction.S:
                    position.Y -= 1;
                    break;
                case Common.Enums.Direction.W:
                    position.X -= 1;
                    break;
                case Common.Enums.Direction.E:
                    position.X += 1;
                    break;
                default:
                    break;
            }
        }
    }
}
