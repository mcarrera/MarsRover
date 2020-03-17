using System;
using System.Collections.Generic;
using System.Linq;
using Domain.Model.Enums;
using Domain.Model.Exceptions;
using Domain.Model.Grid;
using Domain.Model.Messages;
using Domain.Model.Position;
using Domain.Model.Rover;
using Domain.Services.Grid;
using Domain.Services.Rover;

namespace Domain.Controllers
{
  public class MissionController : IMissionController

  {
    private readonly IRoverService _roverService;
    private readonly IGridService _gridService;
    private IGrid _grid;

    public MissionController(IRoverService roverService, IGridService gridService)
    {
      _roverService = roverService;
      _gridService = gridService;
    }

    public MissionResult StartMission(MissionInput missionInput)
    {
      var inputLines = ParseInput(missionInput).ToArray();
      var gridSize = inputLines[0];

      InitialiazeGrid(gridSize);

      var roverInstructions = inputLines.ToList();
      roverInstructions.RemoveAt(0);
      MoveRovers(roverInstructions);

      //
      return new MissionResult();
    }

    private static void MoveRovers(IEnumerable<string> roverInstructions)
    {
      var lines = roverInstructions.ToArray();
      for (var i = 0; i < lines.Count(); i = i + 2)
      {
        IRover rover = null;
        rover = InitializeRover(lines[i]);
        MoveRover(rover, lines[i+1]);
      }
    }



    private static IRover InitializeRover(string initialPosition)
    {
      IRover rover = new Rover();
      var items = initialPosition.Trim().Split(' ');
      rover.SetPosition(new Position
      {
        X = Convert.ToUInt64(items[0]),
        Y = Convert.ToUInt64(items[1])
      });

      switch (items[2].ToUpperInvariant())
      {
        case "N":
          rover.SetHeading(Heading.North);
          break;
        case "S":
          rover.SetHeading(Heading.South);
          break;
        case "E":
          rover.SetHeading(Heading.East);
          break;
        case "W":
          rover.SetHeading(Heading.West);
          break;
        default:
          throw  new MissionInputException($"Invalid input for rover initial direction: ${items[2]}");
        
      }
      
     
      return rover;
    }

    private static void MoveRover(IRover rover, string roverInstructions)
    {
      throw new NotImplementedException();
    }

    /// <summary>
    /// Create a new grid and specify height and width
    /// </summary>
    /// <param name="input"></param>
    private void InitialiazeGrid(string input)
    {
      _grid = new Grid();

      var line = GetLineItems(input).ToArray();

      _grid.SetHeight(Convert.ToUInt64(line[0]));
      _grid.SetWitdh(Convert.ToUInt64(line[1]));
    }

    private static IEnumerable<string> GetLineItems(string input)
    {
      return input.Trim().Split(' ');
    }

    /// <summary>
    /// Perform validation on the input string, and returns the input as lines of input
    /// </summary>
    /// <param name="missionInput"></param>
    /// <returns></returns>
    private static IEnumerable<string> ParseInput(MissionInput missionInput)
    {
      if (string.IsNullOrEmpty(missionInput.Input.Trim()))
        throw new MissionInputException("Empty Input String");

      var lines = missionInput.Input.Split(new[] { Environment.NewLine },
                                          StringSplitOptions.RemoveEmptyEntries);


      if (lines.Length == 0 || lines.Length % 2 != 1)
        throw new MissionInputException("Wrong Format Input String");

      // todo:  validation on 
      return lines;
    }
  }
}
