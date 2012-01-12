using System.Collections.Generic;
using System.Web;
using System.Web.Compilation;
using app.utility;
using app.web.core;
using app.web.core.aspnet;
using app.web.core.stubs;

namespace app.tasks.startup
{
  public class ConfigureTheFrontController : IRunAStartupStep
  {
    IProvideStartupFacilities startup_facility;

    public ConfigureTheFrontController(IProvideStartupFacilities startup_facility)
    {
      this.startup_facility = startup_facility;
    }

    public void run()
    {
      startup_facility.register_factory_for<IProcessRequests, FrontController>();
      startup_facility.register_factory_for<IFindCommands, CommandRegistry>();
      startup_facility.register_instance_for<IEnumerable<IProcessASingleRequest>>(Stub.with<StubFakeSetOfCommands>());
      startup_facility.register_instance_for<WebFormFactory>(BuildManager.CreateInstanceFromVirtualPath);
      startup_facility.register_instance_for<GetTheActiveHttpContext>(() => HttpContext.Current);
      startup_facility.register_factory_for<IDisplayReports, WebFormDisplayEngine>();
      startup_facility.register_factory_for<IProcessASingleRequest, StubMissingCommand>();
      startup_facility.register_factory_for<ICreateRequests, StubRequestFactory>();
      startup_facility.register_factory_for<ICreateViews, WebFormViewFactory>();
      startup_facility.register_factory_for<IFindPathsToTemplates, StubPathRegistry>();
    } 
  }
}
