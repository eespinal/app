using app.utility.containers;

namespace app.web.core.requestmatching
{
  public class IncomingRequest
  {
    public static IBuildRequestMatchers to
    {
      get { return Container.fetch.an<IBuildRequestMatchers>(); }
    }
  }
}