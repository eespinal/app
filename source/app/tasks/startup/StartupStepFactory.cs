using System;

namespace app.tasks.startup
{
  public class StartupStepFactory : ICreateStartupSteps
  {
    IProvideStartupFacilities startup_facility;
    StartupConventionNotFollowedExceptionFactory factory;

    public StartupStepFactory(IProvideStartupFacilities startup_facility,
                              StartupConventionNotFollowedExceptionFactory factory)
    {
      this.startup_facility = startup_facility;
      this.factory = factory;
    }

    public IRunAStartupStep create_from(Type startup_step_type)
    {
      try
      {
        return (IRunAStartupStep) Activator.CreateInstance(startup_step_type, startup_facility);
      }
      catch
      {
        throw factory(startup_step_type);
      }
    }
  }
}