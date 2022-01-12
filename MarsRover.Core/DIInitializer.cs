using System;
using MarsRover.Core.Objects;
using MarsRover.Core.Objects.Interfaces;
using MarsRover.Core.Objects.Interfaces.Base;
using Microsoft.Extensions.DependencyInjection;

namespace MarsRover.Core
{
    public class DIInitializer
    {
        public static IServiceProvider Initialize()
        {
            IServiceCollection services = new ServiceCollection();
            services.AddTransient<IPlateau, Plateau>();
            services.AddTransient<IRover, Rover>();
            services.AddTransient<IObjectPosition, ObjectPosition>();
            return services.BuildServiceProvider();
        }
    }
}
