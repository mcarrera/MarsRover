using System;
using System.Reflection;
using System.Text;
using Domain.Controllers;
using Domain.Model.Messages;
using Domain.Services.Grid;
using Domain.Services.Rover;
using Ninject;

namespace MarsRover
{
  public class Program
  {
   static  IMissionController _missionController ;

    static void Main(string[] args)
    {
      BindDepedencies();
      var missionInput = GetMissionInput();
      if (!ValidateMissionInput(missionInput))
      {
        Console.WriteLine("Input in wrong format. Mission aborted");
        Environment.Exit(0);
      }
      
      var missionResult=   _missionController.StartMission(new MissionInput {Input = missionInput});
      
      Console.WriteLine(missionResult.MissionOutput);


      Console.ReadLine();

    }

    private static bool ValidateMissionInput(string missionInput)
    {
      // TODO:
      // enforce odd number of rows
      return true;
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
       _missionController = new MissionController(roverService, gridService);
    }
  }
}
