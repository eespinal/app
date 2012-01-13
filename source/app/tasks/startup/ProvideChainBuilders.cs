using System;
using System.Collections.Generic;

namespace app.tasks.startup
{
    public class ProvideChainBuilders : IProvideChainBuilders
    {
        IList<IRunAStartupStep> steps;
        ICreateStartupSteps step_factory;

        public ProvideChainBuilders(IList<IRunAStartupStep> steps, ICreateStartupSteps step_factory)
        {
            this.steps = steps;
            this.step_factory = step_factory;
        }

        public IBuildStartupPipelines create_builder_starting_with(Type step_type)
        {
            return new StartupPipelineBuilder(steps,step_factory,step_type);
        }
    }
}