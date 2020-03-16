using Domain.Model.Enums;
using System;
using System.Linq;
using System.Text.RegularExpressions;

namespace Domain.Model.Rover
{
  internal class Rover : IRover
  {

    public Guid Id { get; set; }

    public Rover()
    {
      Position = new Position();
      Id = Guid.NewGuid();
    }

    internal Position Position { get; set; }

    public void SetPosition(string position)
    {
      position = Regex.Replace(position, @"\s+", "");
      Position.X = (uint)char.GetNumericValue(position[0]);
      Position.Y = (uint)char.GetNumericValue(position[1]);
      Position.Heading = GetDirectionFromPosition(position);
    }

    public string GetPosition()
    {
      return $"{Position.X} {Position.Y} {Position.Heading.ToString().First()}"; ;
    }

    private static Heading GetDirectionFromPosition(string position)
    {
      switch (position[2])
      {
        case 'N':
          return Heading.North;
        case 'E':
          return Heading.East;
        case 'S':
          return Heading.South;
        case 'W':
          return Heading.West;
        default:
          throw new ArgumentOutOfRangeException();
      }
    }

    public void MoveForward()
    {
      switch (Position.Heading)
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
      Position.Heading = (Heading)(((int)Position.Heading - 90 + 360) % 360);
    }

    public void RotateRight()
    {
      Position.Heading = (Heading)(((int)Position.Heading + 90) % 360);
    }
  }
}
