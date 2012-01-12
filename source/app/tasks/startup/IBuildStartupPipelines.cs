namespace app.tasks.startup
{
  public interface IBuildStartupPipelines
  {
    IBuildStartupPipelines followed_by<PipelineConfigType>() where PipelineConfigType : IRunAStartupStep;
    void end_with<StartupStep>() where StartupStep : IRunAStartupStep;
  }
}