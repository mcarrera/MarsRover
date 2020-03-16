using System.Collections.Generic;
using Domain.Model.Rover;

namespace Domain.Model.Grid
{
  class Grid : IGrid
  {
    private readonly IList<IRover> _rovers;

    private uint _height;

    private uint _width;
    private IGrid _gridImplementation;

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

    public bool IsPositionOutSideGrid(Position position)
    {
      return false;
    }
  }
}
