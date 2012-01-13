using app.utility.containers.core;

namespace app.utility.logger
{
  public class Log
  {
    public static ILog an
    {
      get
      {
        return Container.fetch.an<ICreateLoggers>().create_logger_bound_to(
          Container.fetch.an<IResolveTheCallingType>().get_the_calling_type());
      }
    }
  }
}