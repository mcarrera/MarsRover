namespace Domain.Model.Rover
{
  public interface IRover
  {
    void SetPosition(string position);

    string GetPosition();

    void MoveForward();

    void RotateLeft();

    void RotateRight();

  }
}
