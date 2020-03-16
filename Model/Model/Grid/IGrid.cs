using Domain.Model.Rover;

namespace Domain.Model.Grid
{
  interface IGrid
  {
    void AddRover(IRover rover);
    void SetSize(uint width, uint height);

    uint GetWidth();
    uint GetHeight();

    bool IsPositionOutSideGrid(Position.Position position);
  }




}
