﻿using Domain.Model.Grid;

namespace Domain.Services.Grid
{
  public class GridService : IGridService
  {

    public void SetGridHeight(IGrid grid, ulong height)
    {
      grid.SetHeight(height);
    }

    public void SetGridWidth(IGrid grid, ulong width)
    {
      grid.SetWitdh(width);
    }

    public ulong GetGridHeight(IGrid grid)
    {
      return grid.GetHeight();
    }

    public ulong GetGridWidth(IGrid grid)
    {
      return grid.GetWidth();
    }
  }
}
