using Machine.Specifications;
using app.specs.utility;
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
                pipeline_builder = fake.an<IBuildAnStartupPipeline>();
                Start.factory = () => pipeline_builder;
            };

            Because of = () =>  result = Start.by;

            It should_return_the_startup_pipeline_builder = () => result.ShouldEqual(pipeline_builder);

            static IBuildAnStartupPipeline pipeline_builder;
        }
    }
}