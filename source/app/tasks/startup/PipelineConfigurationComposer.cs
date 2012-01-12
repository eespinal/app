using System;

namespace app.tasks.startup
{
    public class PipelineConfigurationComposer : IComposePipelineConfiguration
    {

        public IComposePipelineConfiguration followed_by<PipelineConfigType>() where PipelineConfigType : IRunAStartupStep
        {
            throw new NotImplementedException();
        }
    }
}