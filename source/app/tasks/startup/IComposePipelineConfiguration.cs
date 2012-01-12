namespace app.tasks.startup
{
    public interface IComposePipelineConfiguration
    {
        IComposePipelineConfiguration followed_by<PipelineConfigType>() where PipelineConfigType : IRunAStartupStep;
    }
}