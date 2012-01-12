namespace app.tasks.startup
{
  public class StartupPipelineProvider : ICreateStartupPipelineBuilders
  {
    IProvideChainBuilders builder_factory;

    public StartupPipelineProvider(IProvideChainBuilders builder_factory)
    {
      this.builder_factory = builder_factory;
    }

    public IBuildStartupPipelines running<StartupStep>() where StartupStep : IRunAStartupStep
    {
      return builder_factory.create_builder_starting_with(typeof(StartupStep));
    }
  }
}