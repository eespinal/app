using app.utility;
using app.web.application.catalogbrowing.stubs;
using app.web.core;
using app.web.core.stubs;

namespace app.web.application.catalogbrowing
{
  public class ViewTheMainDepartmentsInTheStore : ISupportAStory
  {
    IGetDepartments department_repository;
    IDisplayReports display_engine;

    public ViewTheMainDepartmentsInTheStore():this(Stub.with<StubDepartmentRepository>(),
      Stub.with<StubDisplayEngine>())
    {
    }

    public ViewTheMainDepartmentsInTheStore(IGetDepartments department_repository, IDisplayReports display_engine)
    {
      this.department_repository = department_repository;
      this.display_engine = display_engine;
    }

    public void process(IProvideDetailsToCommands the_request)
    {
      display_engine.display(department_repository.get_the_main_departments());
    }
  }
}