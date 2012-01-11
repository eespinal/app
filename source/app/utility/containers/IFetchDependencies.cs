using System;

namespace app.utility.containers
{
  public interface IFetchDependencies
  {
    Dependency an<Dependency>();
  }

  public class DependencyContainer : IFetchDependencies
  {
    public Dependency an<Dependency>()
    {
    }
  }
}