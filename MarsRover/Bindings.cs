using Domain.Model.Grid;
using Domain.Services.Grid;
using Domain.Services.Rover;
using Ninject.Modules;

namespace MarsRover
{
  public class Bindings : NinjectModule
  {
    public override void Load()
    {
      Bind<IRoverService>().To<RoverService>();
      Bind<IGridService>().To<GridService>();
      Bind<IGrid>().To<Grid>();
    }
  }
}
