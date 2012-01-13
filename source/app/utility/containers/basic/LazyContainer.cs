using System;
using app.utility.containers.core;

namespace app.utility.containers.basic
{
  public class LazyContainer:IFetchDependencies
  {
    public Dependency an<Dependency>()
    {
      return Container.fetch.an<Dependency>();
    }

    public object an(Type dependency)
    {
      return Container.fetch.an(dependency);
    }
  }
}