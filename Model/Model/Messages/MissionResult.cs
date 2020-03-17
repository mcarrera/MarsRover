using System;
using System.Collections.Generic;

namespace Domain.Model.Messages
{
  public class MissionResult
  {
    public bool MissionIsSuccess { get; set; }
    public Dictionary<Guid, string> RoversOutput { get; set; }
  }
}
