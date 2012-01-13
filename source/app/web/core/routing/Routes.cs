using app.utility.containers.core;

namespace app.web.core.routing
{
  public class Routes
  {
    public static IRegisterRoutes register
    {
      get { return Container.fetch.an<IRegisterRoutes>(); }
    }
  }
}