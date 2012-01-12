using Machine.Specifications;
using app.tasks.startup;
using developwithpassion.specifications.rhinomocks;
using developwithpassion.specifications.extensions;

namespace app.specs
{
    public class StartupPipelineBuilderSpecs : Observes<IBuildAnStartupPipeline, StartupPipelineBuilder>
    {
        public class when_running
        {
            Establish context = () =>
            {
                configured_pipeline_builder = fake.an<IComposePipelineConfiguration>();
                configured_pipeline_builder_factory = depends.on<ICreateConfiguredPipelineBuilder>();
                configured_pipeline_builder_factory.setup(x => x.create_configure_pipeline_builder<FirstPipelineConfiguration>()).Return(configured_pipeline_builder);
            };

            Because of = () => result = sut.running<FirstPipelineConfiguration>();

            It should_return_the_configured_pipeline_builder_for_the_current_pipeline =
                () => result.ShouldEqual(configured_pipeline_builder);


            static IComposePipelineConfiguration result;
            static IComposePipelineConfiguration configured_pipeline_builder;
            static ICreateConfiguredPipelineBuilder configured_pipeline_builder_factory;
        }

        public class FirstPipelineConfiguration : IRunAStartupStep
        {
            public void run()
            {
                throw new System.NotImplementedException();
            }
        }
    }
}