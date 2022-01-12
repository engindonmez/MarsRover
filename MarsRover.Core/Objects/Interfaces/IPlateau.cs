using MarsRover.Core.Objects.Interfaces.Base;
using System.Collections.Generic;

namespace MarsRover.Core.Objects.Interfaces
{
    public interface IPlateau
    {
        public int XLength { get; set; }
        public int YLength { get; set; }
        public IList<IPlateauObject> PlateauObjects { get; set; }

        /// <summary>
        /// Initialize with size properties.
        /// </summary>
        /// <param name="plateauSize"></param>
        void Initialize(string plateauSize);
    }
}
