using Machine.Specifications;
using app.tasks.startup;
using developwithpassion.specifications.rhinomocks;

namespace app.specs
{
  public class StartSpecs : Observes
  {
    public class when_by
    {
      static object result;

      Establish context = () =>
      {
        pipeline_builders_builder = fake.an<ICreateStartupPipelineBuilders>();
        GetStartupPipelineBuilder factory = () => pipeline_builders_builder;
        spec.change(() => Start.factory).to(factory);
      };

      Because of = () => result = Start.by;

      It should_return_the_startup_pipeline_builder = () => result.ShouldEqual(pipeline_builders_builder);

      static ICreateStartupPipelineBuilders pipeline_builders_builder;
    }

    public class when_composing_a_pipeline_at_runtime
    {
      Because b = () =>
      {
        Start.by.running<FirstStep>()
          .end_with<SecondStep>();
      };

      It should_run_all_steps = () =>
      {
        FirstStep.ran.ShouldBeTrue();
        SecondStep.ran.ShouldBeTrue();
      };
    }

    public class SecondStep : IRunAStartupStep
    {
      IProvideStartupFacilities facilities;
      public static bool ran;

      public SecondStep(IProvideStartupFacilities facilities)
      {
        this.facilities = facilities;
      }

      public void run()
      {
        ran = true;
      }
    }
    public class FirstStep : IRunAStartupStep
    {
      IProvideStartupFacilities facilities;
      public static bool ran;

      public FirstStep(IProvideStartupFacilities facilities)
      {
        this.facilities = facilities;
      }

      public void run()
      {
        ran = true;
      }
    }
  }
}