using System;

namespace Domain.Model.Exceptions
{
  public class OutOfBoundariesException : Exception
  {
    public OutOfBoundariesException()
    {
    }

    public OutOfBoundariesException(string message) : base(message)
    {
    }

    public OutOfBoundariesException(string message, Exception inner) : base(message, inner)
    {
    }
  }
}
