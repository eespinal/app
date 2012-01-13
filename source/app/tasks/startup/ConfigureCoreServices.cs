using app.utility.containers.core;

namespace app.tasks.startup
{
  public class ConfigureCoreServices : IRunAStartupStep
  {
    IProvideStartupFacilities startup_facilities;

    public ConfigureCoreServices(IProvideStartupFacilities startup_facilities)
    {
      this.startup_facilities = startup_facilities;
    }

    public void run()
    {
      var container = StartupItems.for_pipeline.create_main_container_using(startup_facilities);
      ContainerFacadeResolver resolver = () => container;
      Container.facade_resolver = resolver;
    }
  }
}