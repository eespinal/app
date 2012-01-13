using Machine.Specifications;
using app.tasks.startup;
using developwithpassion.specifications.extensions;
using developwithpassion.specifications.rhinomocks;

namespace app.specs
{
  [Subject(typeof(ChainBuilderProvider))]
  public class ChainBuilderProviderSpecs
  {
    public abstract class concern : Observes<IProvideChainBuilders,
                                      ChainBuilderProvider>
    {
    }

    public class when_providing_a_chain_builder_for_a_type : concern
    {
      Establish context = () =>
      {
        startup_step = fake.an<IRunAStartupStep>();
        startup_steps_creator = depends.on<ICreateStartupSteps>();
        startup_steps_creator.setup(x => x.create_from(typeof(Step)))
          .Return(startup_step);
      };

      Because of = () =>
        result = sut.create_builder_starting_with(typeof(Step));

      It should_return_a_not_null_instance = () =>
      {
        var builder = result.ShouldBeAn<StartupPipelineBuilder>();
        builder.steps.ShouldContainOnly(startup_step);
      };

      static IBuildStartupPipelines result;
      static ICreateStartupSteps startup_steps_creator;
      static IRunAStartupStep startup_step;
    }

    public class Step : IRunAStartupStep
    {
      public void run()
      {
      }
    }
  }
}