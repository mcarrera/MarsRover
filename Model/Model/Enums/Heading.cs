using System.ComponentModel;

namespace Domain.Model.Enums
{
  public enum Heading
  {
    [Description("N")] North = 0,
    [Description("E")] East = 90,
    [Description("S")] South = 180,
    [Description("W")] West = 270
  }
}
