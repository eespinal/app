using System;
using System.Collections.Generic;

namespace app.tasks.startup
{
    public class ChainBuilderProvider : IProvideChainBuilders
    {
        ICreateStartupSteps step_factory;

        public ChainBuilderProvider(ICreateStartupSteps step_factory)
        {
            this.step_factory = step_factory;
        }

        public IBuildStartupPipelines create_builder_starting_with(Type step_type)
        {
            return new StartupPipelineBuilder(new List<IRunAStartupStep>(), step_factory,step_type);
        }
    }
}