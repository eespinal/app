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

        public IComposePipelineConfiguration running<PipelineConfigType>()
        {
//            return configured_pipeline_builder_factory.create_configure_pipeline_builder().followed_by<PipelineConfigType>();
            throw new NotImplementedException();
        }
    }
}