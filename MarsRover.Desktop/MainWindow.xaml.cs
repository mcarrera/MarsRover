using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Domain.Controllers;
using Domain.Model.Messages;
using Domain.Services.Grid;
using Domain.Services.Rover;

namespace MarsRover.Desktop
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private readonly IGridService _gridService;
        private readonly IRoverService _roverService;
        private readonly IGridService _grid;
        private readonly IMissionController _missionController;

        public MainWindow(IGridService gridService, IRoverService roverService, IGridService grid)
        {
            _gridService = gridService;
            _roverService = roverService;
            _grid = grid;
            _missionController = new MissionController(_roverService, _gridService);

            InitializeComponent();
        }

        private void GoButton_Click(object sender, RoutedEventArgs routedEventArgs)
        {
            var missionInput = InputTextBox.Text;
            try
            {
                var missionResult = _missionController.StartMission(new MissionInput { Input = missionInput });
                if (missionResult.MissionIsSuccess)
                {
                    DisplayMissionResult(missionResult.RoversOutput);
                }
            }
            catch (Exception e)
            {
                OutputTextBox.Text = e.ToString();
            }
        }

        private void DisplayMissionResult(Dictionary<Guid, string> missionResultRoversOutput)
        {
            OutputTextBox.Text = string.Empty;
            var output = new StringBuilder();
            foreach (var item in missionResultRoversOutput)
            {
                output.AppendLine(item.Value);
            }

            OutputTextBox.Text = output.ToString();
        }

        private void CloseButton_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}
