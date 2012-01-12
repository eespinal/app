namespace app.tasks.startup
{
    public interface ICreateConfiguredPipelineBuilder
    {
        IComposePipelineConfiguration create_configure_pipeline_builder<PipelineConfigType>() where PipelineConfigType : IRunAStartupStep;
    }
}