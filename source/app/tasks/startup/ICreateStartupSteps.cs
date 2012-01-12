using System;

namespace app.tasks.startup
{
  public interface ICreateStartupSteps
  {
    IRunAStartupStep create_from(Type startup_step_type);
  }
}