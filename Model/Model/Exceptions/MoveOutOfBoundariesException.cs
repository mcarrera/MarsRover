using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Model.Exceptions
{
  public class MoveOutOfBoundariesException : Exception
  {
    public MoveOutOfBoundariesException()
    {
    }

    public MoveOutOfBoundariesException(string message) : base(message)
    {
    }

    public MoveOutOfBoundariesException(string message, Exception inner) : base(message, inner)
    {
    }
  }
}
