namespace app.tasks.startup
{
  public class Start
  {
    public static GetStartupPipelineBuilder factory = StartupItems.for_pipeline.pipeline_builder_factory;

    public static ICreateStartupPipelineBuilders by
    {
      get { return factory(); }
    }
  }
}