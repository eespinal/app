using System;

namespace app.utility.logger
{
  public delegate string LogMessageFormatter(Type type_needing_loggin,string message);
}