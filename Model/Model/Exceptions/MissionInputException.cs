using System;

namespace Domain.Model.Exceptions
{
  public class MissionInputException : Exception
  {
    public MissionInputException()
    {
    }

    public MissionInputException(string message) : base(message)
    {
    }

    public MissionInputException(string message, Exception inner) : base(message, inner)
    {
    }
  }
}
