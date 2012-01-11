using Machine.Specifications;
using app.utility.containers;
using developwithpassion.specifications.rhinomocks;

namespace app.specs
{
  [Subject(typeof(Container))]
  public class ContainerSpecs
  {
    public abstract class concern : Observes
    {
    }

    public class when_providing_access_to_the_container_facade : concern
    {
      Establish c = () =>
      {
        the_facade = fake.an<IFetchDependencies>();
        ContainerFacadeResolver resolver = () => the_facade;
        spec.change(() => Container.facade_resolver).to(resolver);
      };

      Because b = () =>
        result = Container.fetch;

      It should_return_the_container_facade_configured_at_startup = () =>
        result.ShouldEqual(the_facade);

      static IFetchDependencies result;
      static IFetchDependencies the_facade;
    }
  }
}