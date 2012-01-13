using System;
using System.Collections.Generic;
using app.utility.containers.basic;
using app.utility.containers.core;
using app.utility.logger;
using app.utility.logger.basic;
using app.web.core.aspnet;

namespace app.tasks.startup
{
  public class StartupItems
  {
    public class logging_formats
    {
      public static LogMessageFormatter basic = (type, message) =>
        string.Format("{0} - {1}", type.Name, message);

    }
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

      public static TemplatePathAlreadyRegisteredExceptionFactory path_already_registered = report_model_type =>
      {
        throw new NotImplementedException(String.Format(
          "There is already a template registered for {0}", report_model_type.Name));
      };
    }

    public class for_pipeline
    {
      public static IFetchDependencies create_main_container_using(IEnumerable<ICreateASingleDependency> dependencies)
      {
        return new DependencyContainer(new DependencyFactoryRegistry(dependencies,
                                                                     exception_factories.
                                                                       dependency_factory_not_registered),
                                       exception_factories.dependency_creation);
      }
      static ICreateDependencyFactories create_factories_provider()
      {
        return new DependencyFactoriesProvider(new LazyContainer(), new GreediestCtorPicker());
      }

      static IProvideStartupFacilities create_facilities()
      {
        return new StartupFacilities(new List<ICreateASingleDependency>(),
                                     create_factories_provider(), new TypeMatcherFactory());
      }
      static ChainBuilderProvider create_pipeline_builder_provider()
      {
        return new ChainBuilderProvider(new StartupStepFactory(create_facilities(), exception_factories.startup_convention_not_followed));
      }

      public static GetStartupPipelineBuilder pipeline_builder_factory = () =>
      {
        return new StartupPipelineProvider(create_pipeline_builder_provider());
      };

    }
  }
}