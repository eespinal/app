using Machine.Specifications;
using app.utility;
using developwithpassion.specifications.rhinomocks;
using developwithpassion.specifications.extensions;

namespace app.specs
{
  [Subject(typeof(Stub))]
  public class StubSpecs
  {
    public abstract class concern : Observes
    {
    }

    public class when_creating_a_stub_instance : concern
    {
      It should_return_the_instance_specified = () =>
        Stub.with<SomeStub>().ShouldBeAn<SomeStub>();
    }

    public class SomeStub
    {
    }
  }
}