using System;
using System.Collections.Generic;
using System.Linq;
using Domain.Model.Exceptions;
using Domain.Model.Grid;
using Domain.Model.Messages;
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
      var input = ParseInput(missionInput);
      InitialiazeGrid(missionInput.Input);

      MoveRovers(missionInput.Input);

      //
      return new MissionResult();
    }

    private void MoveRovers(string missionInputInput)
    {
     
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

      // todo: more validations
      return lines;
    }
  }
}
