 using System.Web;
 using Machine.Specifications;
 using app.specs.utility;
 using app.web.core;
 using app.web.core.aspnet;
 using developwithpassion.specifications.rhinomocks;
 using developwithpassion.specifications.extensions;

namespace app.specs
{  
  [Subject(typeof(ASPHandler))]  
  public class ASPHandlerSpecs
  {
    public abstract class concern : Observes<IHttpHandler,
                                      ASPHandler>
    {
        
    }

   
    public class when_processing_an_http_context : concern
    {
      Establish c = () =>
      {
        new_request = fake.an<IProvideDetailsToCommands>();
        a_context = ObjectFactory.web.create_http_context();
        front_controller = depends.on<IProcessRequests>();
        request_factory = depends.on<ICreateRequests>();

        request_factory.setup(x => x.create_request_from(a_context)).Return(new_request);
      };

      Because b = () =>
        sut.ProcessRequest(a_context);

      It should_delegate_the_processing_of_a_new_controller_request_to_the_front_controller = () =>
        front_controller.received(x => x.process(new_request));

      static IProcessRequests front_controller;
      static IProvideDetailsToCommands new_request;
      static HttpContext a_context;
      static ICreateRequests request_factory;
    }
  }
}
