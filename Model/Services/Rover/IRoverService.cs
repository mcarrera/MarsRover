using Domain.Model.Rover;

namespace Domain.Services.Rover
{
  public interface IRoverService
  {
    void SetRoverPosition(IRover rover, string position);

    string GetRoverPosition(IRover rover);

    void MoveRover(IRover rover, string instructions);
  }
}
