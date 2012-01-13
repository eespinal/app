using System;
using System.Diagnostics;

namespace app.utility.logger.core
{
  public class CallingTypeResolver : IResolveTheCallingType
  {
    public Type get_the_calling_type()
    {
      return new StackFrame(1).GetMethod().DeclaringType;
    }
  }
}