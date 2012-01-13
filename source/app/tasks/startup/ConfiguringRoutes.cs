using System.Collections.Generic;
using app.utility;
using app.web.application.catalogbrowing;
using app.web.application.catalogbrowing.stubs;
using app.web.core;
using app.web.core.routing;

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
      Routes.register.a_report<ViewTheMainDepartmentsRequest, GetTheMainDepartments, IEnumerable<Department>>();
      Routes.register.a_report <ViewTheDepartmentsInADepartmentRequest, GetDepartmentsInDepartment, IEnumerable<Department>>();
      Routes.register.a_report<ViewTheProductsInADepartmentRequest, GetDepartmentProducts, IEnumerable<Product>>();
    }
  }

  public class GetDepartmentProducts : IQueryForAReportModel<IEnumerable<Product>>
  {
    public IEnumerable<Product> fetch_using(IProvideDetailsToCommands request)
    {
      return Stub.with<StubStoreCatalog>().get_products_of(request.map<Department>());
    }
  }

  public class GetDepartmentsInDepartment : IQueryForAReportModel<IEnumerable<Department>>
  {
    public IEnumerable<Department> fetch_using(IProvideDetailsToCommands request)
    {
      return Stub.with<StubStoreCatalog>().get_sub_departments_of(request.map<Department>());
    }
  }

  public class GetTheMainDepartments : IQueryForAReportModel<IEnumerable<Department>>
  {
    public IEnumerable<Department> fetch_using(IProvideDetailsToCommands request)
    {
      return Stub.with<StubStoreCatalog>().get_the_main_departments();
    }
  }
}