 using System.Reflection;
 using Machine.Specifications;
 using app.tasks.startup;
 using app.utility.containers.core;
 using developwithpassion.specifications.rhinomocks;
 using developwithpassion.specifications.extensions;

namespace app.specs
{  
    [Subject(typeof(CreateStartupSteps))]  
    public class CreateStartupStepsSpecs
    {
        public abstract class concern : Observes<ICreateStartupSteps,
                                            CreateStartupSteps>
        {
        
        }

   
        public class when_creating_an_startup_step : concern
        {
            public class and_it_follows_the_convention
            {
                Establish context = () =>
                {
                    provide_startup_facilities = depends.on<IProvideStartupFacilities>();
                };

                Because b = () =>
                            result = sut.create_from(typeof (Step));

                It should_return_an_instance_of_the_step = () => result.ShouldBeAn<Step>();

                static IRunAStartupStep result;
                static IProvideStartupFacilities provide_startup_facilities;
            }
        
                   
    public class Step : IRunAStartupStep
    {
        public Step(IProvideStartupFacilities facilities)
        {
        }

        public void run()
        {
            
        }
    }
        }
    }

}
