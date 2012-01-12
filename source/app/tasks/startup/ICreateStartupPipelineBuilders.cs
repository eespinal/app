namespace app.tasks.startup
{
    public interface ICreateStartupPipelineBuilders
    {
        IBuildStartupPipelines running<StartupStep>() where StartupStep: IRunAStartupStep;
    }
}