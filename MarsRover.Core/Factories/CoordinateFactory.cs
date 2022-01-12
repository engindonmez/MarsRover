using MarsRover.Common.Enums;
using MarsRover.Core.Objects.Interfaces;
using MarsRover.Core.Objects.Interfaces.Base;
using System;

namespace MarsRover.Core.Factories
{
    public class CoordinateFactory
    {
        public static void CreatePlatosize(string plateauSize, IPlateau plateau)
        {
            if (!string.IsNullOrWhiteSpace(plateauSize))
            {
                var plateauSizes = plateauSize.Split(' ');
                if (plateauSizes.Length == 2)
                {
                    int xLength;
                    if (int.TryParse(plateauSizes[0], out xLength))
                    {
                        int yLength;
                        if (int.TryParse(plateauSizes[1], out yLength))
                        {
                            plateau.XLength = xLength;
                            plateau.YLength = yLength;
                            return;
                        }
                    }
                }
            }
            throw new InvalidCastException("Your size inputs are invalid!");
        }

        public static void CreateRoverPosition(string position, IObjectPosition roverPosition)
        {
            if (!string.IsNullOrWhiteSpace(position))
            {
                var positionArgs = position.Split(' ');
                if (positionArgs.Length == 3)
                {
                    int xLength;
                    if (int.TryParse(positionArgs[0], out xLength))
                    {
                        roverPosition.X = xLength;
                        int yLength;
                        if (int.TryParse(positionArgs[1], out yLength))
                        {
                            roverPosition.Y = yLength;
                            try
                            {
                                roverPosition.Direction = (Direction)Enum.Parse(typeof(Direction), positionArgs[2].ToUpper());
                                return;
                            }
                            catch
                            {
                                throw new InvalidCastException("Your position inputs are invalid!");
                            }
                        }
                    }
                }
            }
            throw new InvalidCastException("Your position inputs are invalid!");
        }
    }
}
