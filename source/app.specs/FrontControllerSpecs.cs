 using Machine.Specifications;
 using app.web.core;
 using developwithpassion.specifications.rhinomocks;
 using developwithpassion.specifications.extensions;

namespace app.specs
{  
  [Subject(typeof(FrontController))]  
  public class FrontControllerSpecs
  {
    public abstract class concern : Observes<IProcessRequests,
                                      FrontController>
    {
        
    }

   
    public class when_processing_a_request : concern
    {
      Establish c = () =>
      {
        the_request = fake.an<IProvideDetailsToCommands>();
        command_registry = depends.on<IFindCommands>();
        command_that_can_process_request = fake.an<IProcessASingleRequest>();

        command_registry.setup(x => x.get_the_command_that_can_process(the_request)).Return(
          command_that_can_process_request);
      };

      Because b = () =>
        sut.process(the_request);

      It should_delegate_the_processing_to_the_command_that_can_process_the_request = () =>
        command_that_can_process_request.received(x => x.process(the_request));

      static IProcessASingleRequest command_that_can_process_request;
      static IProvideDetailsToCommands the_request;
      static IFindCommands command_registry;
    }
  }
}
