using System;

namespace app.tasks.startup
{
    public class StartupPipelineBuilder : IBuildAnStartupPipeline
    {
        readonly ICreateConfiguredPipelineBuilder configured_pipeline_builder_factory;

        public StartupPipelineBuilder(ICreateConfiguredPipelineBuilder configured_pipeline_builder_factory)
        {
            this.configured_pipeline_builder_factory = configured_pipeline_builder_factory;
        }

        public IComposePipelineConfiguration running<PipelineConfigType>() where PipelineConfigType : IRunAStartupStep
        {
            return configured_pipeline_builder_factory.create_configure_pipeline_builder<PipelineConfigType>();
        }
    }
}