using System;

namespace app.tasks.startup
{
    public class CreateConfiguredPipelineBuilder : ICreateConfiguredPipelineBuilder
    {
        public IComposePipelineConfiguration create_configure_pipeline_builder<PipelineConfigType>() where PipelineConfigType : IRunAStartupStep
        {
            throw new NotImplementedException();
        }
    }
}