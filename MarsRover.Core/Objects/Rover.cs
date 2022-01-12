using System.Collections.Generic;
using MarsRover.Common.Exceptions;
using MarsRover.Core.Commands.Interfaces;
using MarsRover.Core.Objects.Interfaces;
using MarsRover.Core.Factories;
using System.Linq;
using MarsRover.Core.Objects.Interfaces.Base;

namespace MarsRover.Core.Objects
{
    public class Rover : IRover
    {
        #region Fields
        public IObjectPosition Position { get; set; }
        public IPlateau Plateau { get; set; }
        public IList<ICommand> Commands { get; set; }
        #endregion

        #region Constructors
        public Rover(IObjectPosition position)
        {
            this.Position = position;
            Commands = new List<ICommand>();
        }
        #endregion

        #region Methods        
        public void Initialize(string position, string commandList, IPlateau plateau)
        {
            this.Plateau = plateau;
            this.Position.Initialize(position);
            CommandFactory.ParseCommandList(commandList, this.Commands);
        }

        public void Process()
        {
            foreach (var command in this.Commands)
            {
                command.Process(this.Position);
                CheckRoverPlateauLimit();
                CheckCrash();
            }
        }

        public string GetOutput()
        {
            return $"{this.Position.X} {this.Position.Y} {this.Position.Direction.ToString()}";
        }

        /// <summary>
        /// Check rover is at the valid plateau boundaries
        /// </summary>
        private void CheckRoverPlateauLimit()
        {
            if (this.Position.X > this.Plateau.XLength || this.Position.X < 0)
            {
                throw new OutOfLimitException(this.Plateau.XLength, this.Position.X, "X");
            }

            if (this.Position.Y > this.Plateau.YLength || this.Position.Y < 0)
            {
                throw new OutOfLimitException(this.Plateau.YLength, this.Position.Y, "Y");
            }
        }

        /// <summary>
        /// Check rover is at the valid plateau boundaries
        /// </summary>
        private void CheckCrash()
        {
            if (this.Plateau.PlateauObjects.Count(po => po.Position.X == this.Position.X && po.Position.Y == this.Position.Y) > 1)
            {
                throw new CrachException(this.Position.X, this.Position.Y);
            }
        }
        #endregion
    }
}
