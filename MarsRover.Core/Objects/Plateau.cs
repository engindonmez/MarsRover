using MarsRover.Core.Objects.Interfaces;
using MarsRover.Core.Factories;
using System;
using System.Collections.Generic;
using MarsRover.Core.Objects.Interfaces.Base;

namespace MarsRover.Core.Objects
{
    public class Plateau : IPlateau
    {
        #region Fields
        public int XLength { get; set; }
        public int YLength { get; set; }
        public IList<IPlateauObject> PlateauObjects { get; set; }
        #endregion

        #region Constructors
        public Plateau()
        {
            PlateauObjects = new List<IPlateauObject>();
        }
        #endregion

        #region Methods
        public void Initialize(string plateauSize)
        {
            CoordinateFactory.CreatePlatosize(plateauSize, this);
        }
        #endregion
    }
}
