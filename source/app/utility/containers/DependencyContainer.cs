using System;

namespace app.utility.containers
{
  public class DependencyContainer : IFetchDependencies
  {
    readonly IFindFactoriesForDependencies find_factories_for_dependencies;

    public DependencyContainer(IFindFactoriesForDependencies find_factories_for_dependencies)
    {
      this.find_factories_for_dependencies = find_factories_for_dependencies;
    }

    public Dependency an<Dependency>()
    {
      return (Dependency) find_factories_for_dependencies.get_factory_that_can_create(typeof(Dependency)).create();
    }

    public object an(Type dependency)
    {
      throw new NotImplementedException();
    }
  }
}