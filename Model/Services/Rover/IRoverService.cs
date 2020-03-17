using Domain.Model.Enums;
using Domain.Model.Position;
using Domain.Model.Rover;

namespace Domain.Services.Rover
{
  public interface IRoverService
  {
    void SetRoverPosition(IRover rover, Position position);

    Position GetRoverPosition(IRover rover);

    void SetRoverHeading(IRover rover, Heading heading);

    Heading GetRoverHeading(IRover rover);

    void MoveRoverForward(IRover rover);

    void RotateRoverLeft(IRover rover);

    void RotateRoverRight(IRover rover);
  }
}
