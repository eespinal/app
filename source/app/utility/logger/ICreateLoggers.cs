using System;

namespace app.utility.logger
{
  public interface ICreateLoggers
  {
    ILog create_logger_bound_to(Type type);
  }
}