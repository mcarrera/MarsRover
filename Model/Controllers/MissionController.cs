using System;
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
      var input = missionInput.Input;

      return new MissionResult();
    }


  }
}
