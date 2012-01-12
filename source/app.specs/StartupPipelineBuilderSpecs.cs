using System.Collections.Generic;
using System.ComponentModel;
using Machine.Specifications;
using app.tasks.startup;
using developwithpassion.specifications.extensions;
using developwithpassion.specifications.rhinomocks;

namespace app.specs
{
  public class StartupPipelineBuilderSpecs
  {

    public class concern : Observes<IBuildStartupPipelines, StartupPipelineBuilder>
    {
      Establish c = () =>
      {
        steps_to_run = new List<IRunAStartupStep>();
        first_step = fake.an<IRunAStartupStep>();
        depends.on(typeof(FirstStep));
        depends.on(steps_to_run);
        step_factory = depends.on<ICreateStartupSteps>();

        step_factory.setup(x => x.create_from(typeof(FirstStep))).Return(first_step);
      };
      
      protected static IList<IRunAStartupStep> steps_to_run;
      protected static ICreateStartupSteps step_factory;
      protected static IRunAStartupStep first_step;
    }

    public class when_created:concern
    {
      It should_add_the_step_to_the_set_of_steps_to_run =
        () => steps_to_run.ShouldContainOnly(first_step);


    }

    public class concern_for_a_builder_with_existing_steps:concern
    {
      
    }

    public class when_followed_by_another_step:concern_for_a_builder_with_existing_steps
    {
      Establish context = () =>
      {
        second_step = fake.an<IRunAStartupStep>();
        step_factory.setup(x => x.create_from(typeof(SecondPipelineConfiguration)))
          .Return(second_step);
      };

      Because b = () =>
        result =sut.followed_by<SecondPipelineConfiguration>();


      It should_add_the_step_to_the_set_of_steps_to_run =
        () => result.downcast_to<StartupPipelineBuilder>().steps.ShouldContainOnly(first_step,second_step);

      It should_return_the_builder_to_continue_specifying_steps = () =>
      {
        var item = result.ShouldBeAn<StartupPipelineBuilder>();
        item.ShouldNotEqual(sut);
        item.steps.ShouldNotEqual(steps_to_run);
      };
        


      static IRunAStartupStep second_step;
      static IBuildStartupPipelines result;
    }

    public class when_finishing_the_chain:concern_for_a_builder_with_existing_steps
    {
      Establish context = () =>
      {
        second_step = fake.an<IRunAStartupStep>();
        step_factory.setup(x => x.create_from(typeof(SecondPipelineConfiguration)))
          .Return(second_step);
      };

      Because b = () =>
        sut.end_with<SecondPipelineConfiguration>();


      It should_run_all_of_the_steps = () =>
      {
        first_step.received(x => x.run());
        second_step.received(x => x.run());
      };

      static IRunAStartupStep second_step;
    }

    public class FirstStep : IRunAStartupStep
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