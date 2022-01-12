using MarsRover.Core.Commands.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarsRover.Core.Objects.Interfaces.Base
{
    public interface IPlateauObject
    {
        IObjectPosition Position { get; set; }
        IPlateau Plateau { get; set; }
        IList<ICommand> Commands { get; set; }

        /// <summary>
        /// Initialize Rover with params.
        /// </summary>
        /// <param name="position">"X Y D" format (D:Direction)</param>
        /// <param name="commandList">Command input</param>
        /// <param name="plateau">Plateau</param>
        void Initialize(string position, string commandList, IPlateau plateau);

        /// <summary>
        /// Process rover commands
        /// </summary>
        void Process();

        /// <summary>
        /// Get Output Value
        /// </summary>
        /// <returns></returns>
        string GetOutput();
    }
}
