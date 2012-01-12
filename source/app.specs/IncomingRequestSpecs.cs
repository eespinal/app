using Machine.Specifications;
using app.specs.utility;
using app.utility.containers;
using app.utility.containers.core;
using app.web.core.requestmatching;
using developwithpassion.specifications.rhinomocks;
using developwithpassion.specifications.extensions;

namespace app.specs
{
  [Subject(typeof(IncomingRequest))]
  public class IncomingRequestSpecs
  {
    public abstract class concern : Observes
    {
    }

    public class when_providing_access_to_the_request_match_gateway : concern
    {
      Establish c = () =>
      {
        builder = ObjectFactory.container.scaffold(spec, fake).an<IBuildRequestMatchers>();
      };

      Because b = () =>
        result = IncomingRequest.to;

      It should_return_the_gateway_configured_at_startup = () =>
        result.ShouldEqual(builder);

      static IBuildRequestMatchers result;
      static IBuildRequestMatchers builder;
      static IFetchDependencies container;
    }
  }
}