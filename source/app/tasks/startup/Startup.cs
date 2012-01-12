using System.Collections.Generic;
using System.Web;
using System.Web.Compilation;
using app.utility;
using app.utility.containers.basic;
using app.utility.containers.core;
using app.web.core;
using app.web.core.aspnet;
using app.web.core.stubs;

namespace app.tasks.startup
{
  public class Startup
  {
    static IList<ICreateASingleDependency> all_factories;
    static IFetchDependencies container;

    public static void run()
    {
      configure_core_items();
      configure_remaining_items();
    }

    static void configure_remaining_items()
    {
      register_factory_for<IProcessRequests, FrontController>();
      register_factory_for<IFindCommands, CommandRegistry>();
      register_instance_for<IEnumerable<IProcessASingleRequest>>(Stub.with<StubFakeSetOfCommands>());
      register_instance_for<WebFormFactory>(BuildManager.CreateInstanceFromVirtualPath);
      register_instance_for<GetTheActiveHttpContext>(() => HttpContext.Current);
      register_factory_for<IDisplayReports,WebFormDisplayEngine>();
        register_factory_for<IProcessASingleRequest,StubMissingCommand>();
        register_factory_for<ICreateRequests,StubRequestFactory >();
        register_factory_for<ICreateViews,WebFormViewFactory >();
        register_factory_for<IFindPathsToTemplates,StubPathRegistry >();
    }

    static void configure_core_items()
    {
      all_factories = new List<ICreateASingleDependency>();

      container = new DependencyContainer(
        new DependencyFactoryRegistry(all_factories,
                                      StartupExceptions.dependency_factory_not_registered),
        StartupExceptions.dependency_creation_exception);

      ContainerFacadeResolver resolver = () => container;
      Container.facade_resolver = resolver;
    }

    static void register_factory_for<Contract>()
    {
      register_factory_for<Contract, Contract>();
    }

    static void register_factory_for<Contract, Implementation>()
    {
      register_factory_for<Contract>(new AutomaticDependencyFactory(
                                       container, new GreediestCtorPicker(), typeof(Implementation)));
    }

    static void register_factory_for<Contract>(ICreateOneType factory)
    {
      all_factories.Add(new DependencyFactory(factory, x => x == typeof(Contract)));
    }

    static void register_instance_for<Contract>(Contract instance)
    {
      register_factory_for<Contract>(new SimpleFactory(() => instance));
    }
  }
}