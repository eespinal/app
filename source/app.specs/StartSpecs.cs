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
        Start.factory = () => pipeline_builders_builder;
      };

      Because of = () => result = Start.by;

      It should_return_the_startup_pipeline_builder = () => result.ShouldEqual(pipeline_builders_builder);

      static ICreateStartupPipelineBuilders pipeline_builders_builder;
    }
  }
}