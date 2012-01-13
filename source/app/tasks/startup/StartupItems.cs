using System;
using System.Collections.Generic;
using app.utility.containers.basic;
using app.utility.containers.core;

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

      public static StartupConventionNotFollowedExceptionFactory startup_convention_not_followed = (type) =>
      {
        throw new NotImplementedException(String.Format(
          "The type {0} does not follow the conventions of a startup step", type.Name));
      };
    }

    public class for_pipeline
    {
      public static GetStartupPipelineBuilder pipeline_builder_factory = () =>
      {
        IProvideStartupFacilities facilities = new StartupFacilities(new List<ICreateASingleDependency>(),
                                                                     new DependencyFactoriesProvider(new LazyContainer(),
                                                                                                     new GreediestCtorPicker
                                                                                                       ()),
                                                                     new TypeMatcherFactory());

        var container = new DependencyContainer(
          new DependencyFactoryRegistry(facilities, exception_factories.dependency_factory_not_registered),
          exception_factories.dependency_creation);

        var builder_provider = new ChainBuilderProvider(
        new StartupStepFactory(facilities, exception_factories.startup_convention_not_followed));

        return new StartupPipelineProvider(builder_provider);
      };
    }
  }
}