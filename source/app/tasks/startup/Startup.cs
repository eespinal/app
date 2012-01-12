using System;
using System.Collections.Generic;
using app.utility.containers.basic;
using app.utility.containers.core;
using app.web.core;

namespace app.tasks.startup
{
  public class Startup
  {
    static IList<ICreateASingleDependency> all_factories;

    public static void run()
    {
      all_factories = new List<ICreateASingleDependency>();
      var container = new DependencyContainer(new DependencyFactoryRegistry(all_factories,
                                                            type_with_no_factory =>
                                                            {
                                                              throw new NotImplementedException(
                                                                string.Format("There is no factory for a {0}",
                                                                              type_with_no_factory));
                                                            }), (type, inner) =>
                                                            {
                                                              throw new NotImplementedException(
                                                                "Failed to create the item");
                                                            });
      ContainerFacadeResolver resolver = () => container;
      Container.facade_resolver = resolver;

    }
  }
}