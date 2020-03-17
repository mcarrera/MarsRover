using Domain.Model.Enums;
using Domain.Model.Position;
using Domain.Model.Rover;

namespace Domain.Services.Rover
{
  public class RoverService : IRoverService
  {
    public void SetRoverPosition(IRover rover, Position position)
    {
      rover.SetPosition(position);
    }

    public Position GetRoverPosition(IRover rover)
    {
      return rover.GetPosition();
    }

    public void SetRoverHeading(IRover rover, Heading heading)
    {
      rover.SetHeading(heading);
    }

    public Heading GetRoverHeading(IRover rover)
    {
      return rover.GetHeading();
    }

    public void MoveRoverForward(IRover rover)
    {
      rover.MoveForward();
    }

    public void RotateRoverLeft(IRover rover)
    {
      rover.RotateLeft();
    }

    public void RotateRoverRight(IRover rover)
    {
      rover.RotateRight();
    }
  }
}
