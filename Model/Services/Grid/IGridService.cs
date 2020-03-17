using Domain.Model.Grid;

namespace Domain.Services.Grid
{
  public interface IGridService
  {
    void SetGridHeight(IGrid grid, ulong height);

    void SetGridWidth(IGrid grid, ulong width);

    ulong GetGridHeight(IGrid grid);

    ulong GetGridWidth(IGrid grid);
  }
}
