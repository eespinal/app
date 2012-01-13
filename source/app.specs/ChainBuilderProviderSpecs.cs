 using System.Collections.Generic;
 using Machine.Specifications;
 using app.tasks.startup;
 using developwithpassion.specifications.rhinomocks;
 using developwithpassion.specifications.extensions;

namespace app.specs
{  
    [Subject(typeof(ProvideChainBuilders))]  
    public class ChainBuilderProviderSpecs
    {
        public abstract class concern : Observes<IProvideChainBuilders,
                                            ProvideChainBuilders>
        {
        
        }

   
        public class when_providing_a_chain_builder_for_a_type : concern
        {
            Establish context = () =>
            {
                steps = new List<IRunAStartupStep>();
                startup_step = fake.an<IRunAStartupStep>();

                depends.on(steps);
                startup_steps_creator = depends.on<ICreateStartupSteps>();

                startup_steps_creator.setup(x=>x.create_from(typeof(Step))).Return(startup_step);
            };

            Because of = () =>
            {
                result = sut.create_builder_starting_with(typeof (Step));
            };

            It should_return_a_not_null_instance = () =>
            {
                var builder = result.ShouldBeAn<StartupPipelineBuilder>();
                steps.ShouldContainOnly(startup_step);
            };

            static IList<IRunAStartupStep> steps;
            static IBuildStartupPipelines result;
            static ICreateStartupSteps startup_steps_creator;
            static IRunAStartupStep startup_step;
        }
    public class Step : IRunAStartupStep
    {
        public void run()
        {
            throw new System.NotImplementedException();
        }
    }
    }

}
