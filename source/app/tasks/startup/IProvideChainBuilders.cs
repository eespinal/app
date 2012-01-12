using System;

namespace app.tasks.startup
{
    public interface IProvideChainBuilders
    {
      IBuildStartupPipelines create_builder_starting_with(Type step_type);
    }
}