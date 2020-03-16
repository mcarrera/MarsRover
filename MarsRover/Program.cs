using System;
using System.Reflection;
using System.Text;
using Domain.Controllers;
using Domain.Services.Grid;
using Domain.Services.Rover;
using Ninject;

namespace MarsRover
{
  public class Program
  {

    static void Main(string[] args)
    {
      BindDepedencies();
      var missionInput = GetMissionInput();
      Console.WriteLine(input);


      Console.Write("Enter to exit");

    }

    private static string GetMissionInput()
    {
      Console.WriteLine("Enter the Mission Input");
      var input = new StringBuilder();
      while (true)
      {
        var line = Console.ReadLine();
        if (line?.Length == 0) return input.ToString();
        input.AppendLine(line);
      }
    }

    private static void BindDepedencies()
    {
      IKernel kernel = new StandardKernel();
      kernel.Load(Assembly.GetExecutingAssembly());
      var roverService = kernel.Get<IRoverService>();
      var gridService = kernel.Get<IGridService>();
      IMissionController missionController = new MissionController(roverService, gridService);
    }
  }
}
