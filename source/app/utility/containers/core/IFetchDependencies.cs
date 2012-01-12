using System;

namespace app.utility.containers.core
{
  public interface IFetchDependencies
  {
    Dependency an<Dependency>();
    object an(Type dependency);
  }
}