using System.Collections.Generic;
using app.utility.containers.basic;
using app.utility.containers.core;

namespace app.tasks.startup
{
  public class Startup
  {
    static IList<ICreateASingleDependency> all_factories;

    public static void run()
    {
      all_factories = new List<ICreateASingleDependency>();

      var container = new DependencyContainer(
        new DependencyFactoryRegistry(all_factories,
            StartupExceptions.dependency_factory_not_registered),
            StartupExceptions.dependency_creation_exception);

      ContainerFacadeResolver resolver = () => container;
      Container.facade_resolver = resolver;
    }
  }
}