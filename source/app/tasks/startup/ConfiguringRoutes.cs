namespace app.tasks.startup
{
  public class ConfiguringRoutes:IRunAStartupStep
  {
    IProvideStartupFacilities startup_facilities;

    public ConfiguringRoutes(IProvideStartupFacilities startup_facilities)
    {
      this.startup_facilities = startup_facilities;
    }

    public void run()
    {
      throw new System.NotImplementedException();
    }
  }
}