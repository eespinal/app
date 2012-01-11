using System;

namespace app.web.core.requestmatching
{
  public class IncomingRequest
  {
    public static RequestBuilderFactory factory = () =>
    {
      throw new NotImplementedException("This needs to be configured at startup");
    };

    public static IBuildRequestMatchers to
    {
      get { return factory(); }
    }
  }
}