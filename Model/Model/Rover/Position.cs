using Domain.Model.Enums;

namespace Domain.Model.Rover
{
  public class Position
  {
    public uint X { get; set; }

    public uint Y { get; set; }

    public Heading Heading { get; set; }
  }
}
