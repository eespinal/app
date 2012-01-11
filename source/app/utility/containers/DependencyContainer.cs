using System;

namespace app.utility.containers
{
  public class DependencyContainer : IFetchDependencies
  {
      readonly IFindFactoriesForDependencies find_factories_for_dependencies;
      readonly ItemCreationExceptionFactory item_creation_exception_factory;
      Type dependency_type;

      public DependencyContainer(IFindFactoriesForDependencies find_factories_for_dependencies, ItemCreationExceptionFactory item_creation_exception_factory)
      {
          this.find_factories_for_dependencies = find_factories_for_dependencies;
          this.item_creation_exception_factory = item_creation_exception_factory;
      }

      public Dependency an<Dependency>()
      {
          dependency_type = typeof(Dependency);
          try
          {
              return (Dependency)find_factories_for_dependencies.get_factory_that_can_create(dependency_type).create();
          }
          catch (Exception ex)
          {

              throw item_creation_exception_factory(dependency_type, ex);

          }
      }
  }
}