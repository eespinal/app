using System;
using System.ComponentModel;

namespace app.tasks.startup
{
    public class PipelineConfigurationComposer : IComposePipelineConfiguration
    {
        readonly IRunAStartupStep step;
        readonly IContainer container;

        public PipelineConfigurationComposer(IRunAStartupStep step,IContainer container)
        {
            this.step = step;
            this.container = container;
        }

        public IComposePipelineConfiguration followed_by<PipelineConfigType>() where PipelineConfigType : IRunAStartupStep
        {
            throw new NotImplementedException();
        }
    }
}