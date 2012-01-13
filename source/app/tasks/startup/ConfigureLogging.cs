using System;
using app.utility.logger;

namespace app.tasks.startup
{
  public class ConfigureLogging:IRunAStartupStep
  {
    IProvideStartupFacilities startup_facilities;

    public ConfigureLogging(IProvideStartupFacilities startup_facilities)
    {
      this.startup_facilities = startup_facilities;
    }

    public void run()
    {
      startup_facilities.register_instance_for<LogWriterFactory>(() => Console.Out);
      startup_facilities.register_factory_for<ICreateLoggers,TextWriterLoggerFactory>();
      startup_facilities.register_instance_for(StartupItems.logging_formats.basic);
    }
  }
}