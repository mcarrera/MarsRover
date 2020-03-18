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
      var result = ProcessRoverInstructions(roverInstructions);

      //
      return new MissionResult { MissionIsSuccess = true, RoversOutput = result };
    }

    private Dictionary<Guid, string> ProcessRoverInstructions(IEnumerable<string> roverInstructions)
    {
      var result = new Dictionary<Guid, string>();
      var lines = roverInstructions.ToArray();
      for (var i = 0; i < lines.Count(); i = i + 2)
      {
        var rover = InitializeRover(lines[i]);
        result.Add(rover.GetId(), ProcessRoverInstruction(rover, lines[i + 1]));
      }

      return result;
    }

    private IRover InitializeRover(string initialPosition)
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
          _roverService.SetRoverHeading(rover, Heading.North);
          break;
        case "S":
          _roverService.SetRoverHeading(rover, Heading.South);
          break;
        case "E":
          _roverService.SetRoverHeading(rover, Heading.East);
          break;
        case "W":
          _roverService.SetRoverHeading(rover, Heading.West);
          break;
        default:
          throw new MissionInputException($"Invalid input for rover initial direction: ${items[2]}");

      }


      return rover;
    }

    private string ProcessRoverInstruction(IRover rover, string roverInstructions)
    {
      foreach (var move in roverInstructions.ToUpperInvariant())
      {
        switch (move)
        {
          case 'L':
            _roverService.RotateRoverLeft(rover);
            break;
          case 'R':
            _roverService.RotateRoverRight(rover);
            break;
          case 'M':
            if (IsMovingWithinBoundaries(rover))
            {
              _roverService.MoveRoverForward(rover);
            }
            else
            {
              throw new OutOfBoundariesException($"Rover stepping out of the grid.");
            }
            break;
          default:
            // todo:?
            break;
        }
      }

      return GetRoverPositionAndHeadingString(rover);

    }

    private string GetRoverPositionAndHeadingString(IRover rover)
    {
      var position = _roverService.GetRoverPosition(rover);
      var heading = _roverService.GetRoverHeading(rover);

      return $"{position.X} {position.Y} {heading.ToString().First()}";
    }

    private bool IsMovingWithinBoundaries(IRover rover)
    {
      var currentPosition = _roverService.GetRoverPosition(rover);
      var heading = _roverService.GetRoverHeading(rover);

      var gridMaxY = _gridService.GetGridHeight(_grid) - 1;
      var gridMaxX = _gridService.GetGridWidth(_grid) - 1;
      switch (heading)
      {
        case Heading.North:
          if (currentPosition.Y == gridMaxY) return false;
          break;
        case Heading.East:
          if (currentPosition.X == gridMaxX) return false;
          break;
        case Heading.South:
          if (currentPosition.Y == 0) return false;
          break;
        case Heading.West:
          if (currentPosition.X == 0) return false;
          break;
        default:
          throw new ArgumentOutOfRangeException();
      }

      return true;
    }

    /// <summary>
    /// Create a new grid and specify height and width
    /// </summary>
    /// <param name="input"></param>
    private void InitialiazeGrid(string input)
    {
      _grid = new Grid();

      var inputs = input.Trim().Split(' ');

      _grid.SetHeight(Convert.ToUInt64(inputs[0]) + 1);
      _grid.SetWitdh(Convert.ToUInt64(inputs[1]) + 1);
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
