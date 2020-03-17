namespace Domain.Model.Grid
{
  public interface IGrid
  {
    void SetWitdh(ulong width);

    void SetHeight(ulong height);

    ulong GetWidth();
    ulong GetHeight();
  }




}
