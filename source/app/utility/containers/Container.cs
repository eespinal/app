using System;

namespace app.utility.containers
{
  public class Container
  {
    public static ContainerFacadeResolver facade_resolver = () =>
    {
      throw new NotImplementedException("This should be configured by a startup process");
    };

    public static IFetchDependencies fetch
    {
      get { return facade_resolver(); }
    }
  }
}