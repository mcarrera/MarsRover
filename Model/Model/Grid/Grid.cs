using System.Collections.Generic;
using Domain.Model.Rover;

namespace Domain.Model.Grid
{
  public class Grid : IGrid
  {
  
    private ulong _height;

    private ulong _width;
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


  }
}
