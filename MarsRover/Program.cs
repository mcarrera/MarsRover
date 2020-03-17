using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;
using Domain.Controllers;
using Domain.Model.Grid;
using Domain.Model.Messages;
using Domain.Services.Grid;
using Domain.Services.Rover;
using Ninject;

namespace MarsRover
{
  public class Program
  {
    static IMissionController _missionController;

    static void Main(string[] args)
    {
      BindDepedencies();
      var missionInput = GetMissionInput();

      var missionResult = _missionController.StartMission(new MissionInput { Input = missionInput });

      if (missionResult.MissionIsSuccess)
      {
        PrintMissionResult(missionResult.RoversOutput);
      }

      Console.ReadLine();

    }

    private static void PrintMissionResult(Dictionary<Guid, string> missionOutput)
    {
      Console.WriteLine("Mission Successful. Results:");
      foreach (var item in missionOutput)
        Console.WriteLine(item.Value);
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
      var grid = kernel.Get<IGrid>();
      _missionController = new MissionController(roverService, gridService);
    }
  }
}
