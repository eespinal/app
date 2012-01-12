using System;

namespace app.tasks.startup
{
  public class Start
  {
    public static GetStartupPipelineBuilder factory = () =>
    {
      throw new NotImplementedException("You need to set this in the bootstrapper");
    };

    public static ICreateStartupPipelineBuilders by
    {
      get { return factory(); }
    }
  }
}