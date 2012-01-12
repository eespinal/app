namespace app.tasks.startup
{
  public class ConfigureCoreItems :IRunAStartupStep
  {
    IProvideStartupFacilities startup_facilities;

    public ConfigureCoreItems(IProvideStartupFacilities startup_facilities)
    {
      this.startup_facilities = startup_facilities;
    }

    public void run()
    {
    }
  }
}