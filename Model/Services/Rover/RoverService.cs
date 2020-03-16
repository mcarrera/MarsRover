using System;
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

    public void MoveRover(IRover rover, string instructions)
    {
      foreach (var item in instructions)
      {
        switch (item)
        {
          case 'L':
            rover.RotateLeft();
            break;
          case 'R':
            rover.RotateRight();
            break;
          case 'M':
            rover.MoveForward();
            break;
          default:
            throw new ArgumentOutOfRangeException();
        }
      }
    }
  }
}
