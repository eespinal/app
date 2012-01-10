using System.Collections.Generic;
using System.Linq;
using Machine.Specifications;
using app.web.core;
using developwithpassion.specifications.rhinomocks;
using developwithpassion.specifications.extensions;

namespace app.specs
{
  [Subject(typeof(CommandRegistry))]
  public class CommandRegistrySpecs
  {
    public abstract class concern : Observes<IFindCommands,
                                      CommandRegistry>
    {
    }

    public class when_finding_a_command_for_a_request : concern
    {
      public class and_it_has_the_command
      {
        Establish c = () =>
        {
          the_request = fake.an<IProvideDetailsToCommands>();
          command_that_can_process_the_request = fake.an<IProcessASingleRequest>();
          all_the_commands = Enumerable.Range(1,100).Select(x => fake.an<IProcessASingleRequest>()).ToList();

          all_the_commands.Add(command_that_can_process_the_request);

          command_that_can_process_the_request.setup(x => x.can_process(the_request)).Return(true);

          depends.on<IEnumerable<IProcessASingleRequest>>(all_the_commands);
        };

        Because b = () =>
          result = sut.get_the_command_that_can_process(the_request);

        It should_return_the_command_to_the_caller = () =>
          result.ShouldEqual(command_that_can_process_the_request);

        static IProcessASingleRequest result;
        static IProcessASingleRequest command_that_can_process_the_request;
        static IProvideDetailsToCommands the_request;
        static List<IProcessASingleRequest> all_the_commands;
      }
      public class and_it_does_not_have_the_command
      {
        Establish c = () =>
        {
          missing_command = depends.on<IProcessASingleRequest>();
          the_request = fake.an<IProvideDetailsToCommands>();
          all_the_commands = Enumerable.Range(1,100).Select(x => fake.an<IProcessASingleRequest>()).ToList();
          depends.on<IEnumerable<IProcessASingleRequest>>(all_the_commands);
        };

        Because b = () =>
          result = sut.get_the_command_that_can_process(the_request);

        It should_return_the_missing_command_to_the_caller = () =>
          result.ShouldEqual(missing_command);

        static IProcessASingleRequest result;
        static IProvideDetailsToCommands the_request;
        static List<IProcessASingleRequest> all_the_commands;
        static IProcessASingleRequest missing_command;
      }
    }
  }
}