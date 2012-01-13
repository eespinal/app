namespace app.tasks.startup
{
  public class ConfigureQueries : IRunAStartupStep
  {
    IProvideStartupFacilities startup_facilities;

    public ConfigureQueries(IProvideStartupFacilities startup_facilities)
    {
      this.startup_facilities = startup_facilities;
    }

    public void run()
    {
      startup_facilities.register_factory_for<GetTheMainDepartments>();
      startup_facilities.register_factory_for<GetDepartmentProducts>();
      startup_facilities.register_factory_for<GetDepartmentsInDepartment>();
    }
  }
}