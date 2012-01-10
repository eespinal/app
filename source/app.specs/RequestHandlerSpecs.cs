using Machine.Specifications;
using app.web.core;
using developwithpassion.specifications.rhinomocks;

namespace app.specs
{
  [Subject(typeof(RequestHandler))]
  public class RequestHandlerSpecs
  {
    public abstract class concern : Observes<IProcessASingleRequest,
                                      RequestHandler>
    {
    }

    public class when_determining_if_it_can_process_a_request : concern
    {
      Establish c = () =>
      {
        the_request = fake.an<IProvideDetailsToCommands>();
        depends.on<RequestCriteria>(x =>
        {
          x.ShouldEqual(the_request);
          return true;
        });
      };

      Because b = () =>
        result = sut.can_process(the_request);

      It should_make_the_determination_by_using_its_request_criteria = () =>
        result.ShouldBeTrue();

      static bool result;
      static IProvideDetailsToCommands the_request;
    }
  }
}