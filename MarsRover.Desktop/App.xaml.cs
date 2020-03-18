using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using Domain.Model.Grid;
using Domain.Services.Grid;
using Domain.Services.Rover;
using Ninject;

namespace MarsRover.Desktop
{
    /// <inheritdoc />
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        private IKernel _container;

        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);
            ConfigureContainer();
            ComposeObjects();
            Current.MainWindow.Show();
        }

        private void ConfigureContainer()
        {
            this._container = new StandardKernel();
            _container.Bind<IRoverService>().To<RoverService>().InTransientScope();
            _container.Bind<IGridService>().To<GridService>().InTransientScope();
            _container.Bind<IGrid>().To<Grid>().InTransientScope();
        }

        private void ComposeObjects()
        {
            Current.MainWindow = this._container.Get<MainWindow>();
            Current.MainWindow.Title = "Mars Rover";
        }
    }
}
