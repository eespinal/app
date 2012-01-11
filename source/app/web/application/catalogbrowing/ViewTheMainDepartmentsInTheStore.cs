using app.web.core;

namespace app.web.application.catalogbrowing
{
  public class ViewTheMainDepartmentsInTheStore : ISupportAStory
  {
    IGetDepartments department_repository;
    IDisplayReports display_engine;

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