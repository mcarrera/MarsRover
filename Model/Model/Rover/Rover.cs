using Domain.Model.Enums;
using System;

namespace Domain.Model.Rover
{
  internal class Rover : IRover
  {

    internal Position.Position Position { get; set; }

    internal Heading Heading;

    public Guid Id { get; set; }

    public Rover()
    {
      Position = new Position.Position();
      Id = Guid.NewGuid();
    }



    public void SetPosition(Position.Position position)
    {
      Position = position;
    }

    public Position.Position GetPosition()
    {
      return Position;
    }

    public void SetHeading(Heading heading)
    {
      Heading = heading;
    }

    public Heading GetHeading()
    {
      return Heading;
    }

    public void MoveForward()
    {
      switch (Heading)
      {
        case Heading.North:
          Position.Y++;
          break;
        case Heading.East:
          Position.X++;
          break;
        case Heading.South:
          Position.Y--;
          break;
        case Heading.West:
          Position.X--;
          break;

        default:
          throw new ArgumentOutOfRangeException();
      }
    }

    public void RotateLeft()
    {
      Heading = (Heading)(((int)Heading - 90 + 360) % 360);
    }

    public void RotateRight()
    {
      Heading = (Heading)(((int)Heading + 90) % 360);
    }
  }
}
