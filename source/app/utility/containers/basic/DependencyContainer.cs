using System;
using app.utility.containers.core;

namespace app.utility.containers.basic
{
  public class DependencyContainer : IFetchDependencies
  {
    IFindFactoriesForDependencies find_factories_for_dependencies;
    ItemCreationExceptionFactory item_creation_exception_factory;

    public DependencyContainer(IFindFactoriesForDependencies find_factories_for_dependencies,
                               ItemCreationExceptionFactory item_creation_exception_factory)
    {
      this.find_factories_for_dependencies = find_factories_for_dependencies;
      this.item_creation_exception_factory = item_creation_exception_factory;
    }

    public Dependency an<Dependency>()
    {
        return (Dependency) an(typeof (Dependency));
    }

    public object an(Type dependency)
    {
       try
        {
            return find_factories_for_dependencies.get_factory_that_can_create(dependency).create();
        }
        catch (Exception ex)
        {
            throw item_creation_exception_factory(dependency, ex);
        }
    }
  }
}