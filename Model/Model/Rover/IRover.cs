﻿using System;
using Domain.Model.Enums;

namespace Domain.Model.Rover
{
  public interface IRover
  {
    Guid GetId();
    void SetPosition(Position.Position position);

    Position.Position GetPosition();

    void SetHeading(Heading heading);

    Heading GetHeading();

    void MoveForward();

    void RotateLeft();

    void RotateRight();
  }
}
