using System.ComponentModel;
using Machine.Specifications;
using app.tasks.startup;
using developwithpassion.specifications.rhinomocks;

namespace app.specs
{
    public class PipelineConfigurationComposerSpecs : Observes<IComposePipelineConfiguration, PipelineConfigurationComposer>
    {
        public class when_followed_by
        {
            public class and_it_follows_all_the_conventions
            {
                Establish context = () =>
                {
                    first_step = new FirstPipelineConfiguration();
                    container = fake.an<IContainer>();
                    second_pipeline_configuration = fake.an<IComposePipelineConfiguration>();
                    depends.on(first_step);
                };

                Because of = () => result = sut.followed_by<FirstPipelineConfiguration>();


                It should_return_a_pipeline_configuration_composer_adding_the_pipeline_to_the_set = () => result.ShouldEqual(second_pipeline_configuration);


                static IComposePipelineConfiguration result;
                static IComposePipelineConfiguration second_pipeline_configuration;
                static IContainer container;
                static FirstPipelineConfiguration first_step;
            }

            public class and_it_does_not_have_a_valid_constructor
            {
            }

            public class and_it_was_registered_previously
            {
            }
        }

        public class FirstPipelineConfiguration : IRunAStartupStep
        {
            public void run()
            {
            }
        }

        public class SecondPipelineConfiguration : IRunAStartupStep
        {
            public void run()
            {
            }
        }
    }
}