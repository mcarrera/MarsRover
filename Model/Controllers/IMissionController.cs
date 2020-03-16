using Domain.Model.Messages;

namespace Domain.Controllers
{
  public interface IMissionController
  {
    MissionResult StartMission(MissionInput missionInput);
  }
}
