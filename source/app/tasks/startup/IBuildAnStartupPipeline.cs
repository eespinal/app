namespace app.tasks.startup
{
    public interface IBuildAnStartupPipeline
    {
        IComposePipelineConfiguration running<PipelineConfigType>() where PipelineConfigType: IRunAStartupStep;
    }
}