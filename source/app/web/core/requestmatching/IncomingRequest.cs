using app.utility.containers.core;

namespace app.web.core.requestmatching
{
  public class IncomingRequest
  {
    public static IBuildRequestMatchers was
    {
      get { return Container.fetch.an<IBuildRequestMatchers>(); }
    }
  }
}