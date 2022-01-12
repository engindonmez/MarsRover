using MarsRover.Core;
using MarsRover.Core.Objects;
using MarsRover.Core.Objects.Interfaces;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Linq;
using Xunit;

namespace MarsRover.Test
{
    public class MarsRoverTest
    {
        [Fact]
        public void HappyPath()
        {
            var output = string.Empty;
            IServiceProvider serviceProvider = DIInitializer.Initialize();

            #region Actions
            var plateau = serviceProvider.GetService<IPlateau>();
            plateau.Initialize("5 5");

            var rover1 = serviceProvider.GetService<IRover>();
            rover1.Initialize("1 2 N", "LMLMLMLMM", plateau);
            rover1.Plateau = plateau;
            plateau.PlateauObjects.Add(rover1);

            var rover2 = serviceProvider.GetService<IRover>();
            rover2.Initialize("3 3 E", "MMRMMRMRRM", plateau);
            rover2.Plateau = plateau;
            plateau.PlateauObjects.Add(rover2);

            foreach (var rover in plateau.PlateauObjects)
            {
                rover.Process();
            }

            output = string.Join('|', plateau.PlateauObjects.Select(r => r.GetOutput()));
            #endregion

            #region Assert
            Assert.Equal("1 3 N|5 1 E", output);
            #endregion
        }
    }
}
