using Domain.Model.Grid;
using Domain.Services.Grid;
using Domain.Services.Rover;
using Ninject.Modules;

namespace MarsRover.Desktop
{
    internal class IocConfiguration : NinjectModule
    {
        public override void Load()
        {
            Bind<IRoverService>().To<RoverService>();
            Bind<IGridService>().To<GridService>();
            Bind<IGrid>().To<Grid>();
        }
    }
}