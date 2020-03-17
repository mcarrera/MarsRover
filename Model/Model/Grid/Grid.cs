using System.Collections.Generic;
using Domain.Model.Rover;

namespace Domain.Model.Grid
{
  public class Grid : IGrid
  {
    private readonly IList<IRover> _rovers;

    private ulong _height;

    private ulong _width;

    public Grid()
    {
      _rovers = new List<IRover>();
    }

    public void AddRover(IRover rover)
    {
      _rovers.Add(rover);
    }

    public void SetWitdh(ulong width)
    {
      _width = width;
    }

    public void SetHeight(ulong height)
    {
      _height = height;
    }

    public ulong GetWidth()
    {
      return _width;
    }

    public ulong GetHeight()
    {
      return _height;
    }

    public bool IsPositionOutSideGrid(Position.Position position)
    {
      return position.X > _width - 1 || position.Y > _height - 1;
    }
  }
}
