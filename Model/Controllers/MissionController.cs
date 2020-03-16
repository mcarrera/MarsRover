using System;
using System.Collections.Generic;
using Domain.Model.Exceptions;
using Domain.Model.Messages;
using Domain.Services.Grid;
using Domain.Services.Rover;

namespace Domain.Controllers
{
  public class MissionController : IMissionController

  {
    private readonly IRoverService _roverService;
    private readonly IGridService _gridService;

    public MissionController(IRoverService roverService, IGridService gridService)
    {
      _roverService = roverService;
      _gridService = gridService;
    }

    public MissionResult StartMission(MissionInput missionInput)
    {
      var input = ParseInput(missionInput);

      //
      return new MissionResult();
    }

    private static IEnumerable<string> ParseInput(MissionInput missionInput)
    {
      if (string.IsNullOrEmpty(missionInput.Input.Trim()))
        throw new MissionInputException("Empty Input String");

      var lines = missionInput.Input.Split(new string[] { Environment.NewLine }, StringSplitOptions.RemoveEmptyEntries))
        
      if (lines.Length == 0 || lines.Length % 2 == 1)
        throw new MissionInputException("Empty Input String");

      return lines;
    }
  }
}
