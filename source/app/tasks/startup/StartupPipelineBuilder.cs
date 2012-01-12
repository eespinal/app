using System;
using System.Collections.Generic;
using System.Linq;

namespace app.tasks.startup
{
  public class StartupPipelineBuilder : IBuildStartupPipelines
  {
    public IList<IRunAStartupStep> steps;
    public ICreateStartupSteps step_factory;

    public StartupPipelineBuilder(IList<IRunAStartupStep> steps, ICreateStartupSteps step_factory, Type first_step)
    {
      this.steps = steps;
      this.step_factory = step_factory;
      steps.Add(step_factory.create_from(first_step));
    }

    public IBuildStartupPipelines followed_by<StartupStep>() where StartupStep : IRunAStartupStep
    {
      return create_builder_with_next_step<StartupStep>();
    }

    StartupPipelineBuilder create_builder_with_next_step<StartupStep>() where StartupStep : IRunAStartupStep
    {
      return new StartupPipelineBuilder(new List<IRunAStartupStep>(steps), step_factory, typeof(StartupStep));
    }

    public void end_with<StartupStep>() where StartupStep : IRunAStartupStep
    {
      create_builder_with_next_step<StartupStep>().steps.ToList().ForEach(x => x.run());
    }
  }
}