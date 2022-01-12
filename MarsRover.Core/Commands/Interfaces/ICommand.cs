using MarsRover.Core.Objects.Interfaces.Base;

namespace MarsRover.Core.Commands.Interfaces
{
    public interface ICommand
    {
        void Process(IObjectPosition position);
    }
}
