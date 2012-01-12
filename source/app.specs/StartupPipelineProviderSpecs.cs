using System;
using Machine.Specifications;
using app.tasks.startup;
using developwithpassion.specifications.extensions;
using developwithpassion.specifications.rhinomocks;

namespace app.specs
{
  public class StartupPipelineProviderSpecs : Observes<ICreateStartupPipelineBuilders, StartupPipelineProvider>
  {
    public class when_the_first_step_is_specified
    {
      Establish context = () =>
      {
        configured_pipeline_builder = fake.an<IBuildStartupPipelines>();
        startup_chain_factory = depends.on<IProvideChainBuilders>();
        startup_chain_factory.setup(x => x.create_builder_starting_with(typeof(FirstStartupStep)))
          .Return(configured_pipeline_builder);
      };

      Because of = () => 
        result = sut.running<FirstStartupStep>();

      It should_return_the_configured_pipeline_builder_for_the_current_pipeline = () => 
        result.ShouldEqual(configured_pipeline_builder);

      static IBuildStartupPipelines result;
      static IBuildStartupPipelines configured_pipeline_builder;
      static IProvideChainBuilders startup_chain_factory;
    }

    public class FirstStartupStep : IRunAStartupStep
    {
      public void run()
      {
        throw new NotImplementedException();
      }
    }
  }
}