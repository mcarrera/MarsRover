using System;
using Domain.Model.Rover;

namespace Domain.Services.Rover
{
  public class RoverService : IRoverService
  {
    public void SetRoverPosition(IRover rover, string position)
    {
      rover.SetPosition(position);
    }

    public string GetRoverPosition(IRover rover)
    {
      return rover.GetPosition();
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
