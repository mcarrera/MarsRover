using System.Collections.Generic;
using Domain.Model.Rover;

namespace Domain.Model.Grid
{
  class Grid : IGrid
  {
    private readonly IList<IRover> _rovers;

    private uint _height;

    private uint _width;
    
    public Grid(IList<IRover> rovers)
    {
      _rovers = rovers;
    }

    public void AddRover(IRover rover)
    {
      _rovers.Add(rover);
    }

    public void SetSize(uint width, uint height)
    {
      _width = width;
      _height = height;
    }

    public uint GetWidth()
    {
      return _width;
    }

    public uint GetHeight()
    {
      return _height;
    }

    public bool IsPositionOutSideGrid(Position.Position position)
    {
      return position.X > _width - 1 || position.Y > _height - 1;
    }
  }
}
