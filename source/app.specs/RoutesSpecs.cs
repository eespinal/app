using Machine.Specifications;
using app.specs.utility;
using app.web.core;
using developwithpassion.specifications.rhinomocks;
using developwithpassion.specifications.extensions;

namespace app.specs
{
  [Subject(typeof(Routes))]
  public class RoutesSpecs
  {
    public abstract class concern : Observes
    {

    }

    public class when_accessing_route_registration : concern
    {
      Establish c = () =>
      {
        route_table = ObjectFactory.container.scaffold(spec, fake).an<IRegisterRoutes>();
      };

      Because b = () =>
        result = Routes.register;

      It should_return_the_route_table = () =>
        result.ShouldEqual(route_table);

      static IRegisterRoutes result;
      static IRegisterRoutes route_table;
    }
  }
}
