using System;
using app.utility.containers.basic;

namespace app.tasks.startup
{
  public class StartupItems
  {
    public class exception_factories
    {
      public static MissingDependencyFactory dependency_factory_not_registered = (type) =>
      {
        throw new NotImplementedException(String.Format("The type {0} has no factory to create it", type.Name));
      };

      public static ItemCreationExceptionFactory dependency_creation = (type, inner) =>
      {
        throw new NotImplementedException(String.Format("The type {0} had errors when being created", type.Name), inner);
      };
    }

    public class for_pipeline
    {
      public static GetStartupPipelineBuilder pipeline_builder_factory = () =>
      {
        throw new NotImplementedException();
      };
    }
  }
}
