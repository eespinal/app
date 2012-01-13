using System.Collections.Generic;
using app.web.application.catalogbrowing;
using app.web.core;

namespace app.tasks.startup
{
  public class ConfiguringRoutes : IRunAStartupStep
  {
    IProvideStartupFacilities startup_facilities;

    public ConfiguringRoutes(IProvideStartupFacilities startup_facilities)
    {
      this.startup_facilities = startup_facilities;
    }

    public void run()
    {
      Routes.register.a_report<ViewTheMainDepartmentsRequest, First, IEnumerable<Department>>();
    }
  }

  public class First : IFetchA<IEnumerable<Department>>
  {
    public IEnumerable<Department> fetch_using(IProvideDetailsToCommands request)
    {
      throw new System.NotImplementedException();
    }
  }
}