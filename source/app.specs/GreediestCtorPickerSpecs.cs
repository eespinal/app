using System.Reflection;
using Machine.Specifications;
using app.specs.utility;
using app.utility.containers.core;
using developwithpassion.specifications.rhinomocks;

namespace app.specs
{
  [Subject(typeof(GreediestCtorPicker))]
  public class GreediestCtorPickerSpecs
  {
    public abstract class concern : Observes<IPickTheCtorOnTheType,
                                      GreediestCtorPicker>
    {
    }

    public class when_getting_the_ctor_for_a_type : concern
    {
      Establish c = () =>
      {
        greediest_ctor = ObjectFactory.expressions.to_target<AutomaticDependencyFactorySpecs.OurTypeWithDependencies>()
          .get_ctor_pointed_at_by(() => new AutomaticDependencyFactorySpecs.OurTypeWithDependencies(null, null, null));
      };

      Because b = () =>
        result = sut.get_applicable_ctor_on(typeof(AutomaticDependencyFactorySpecs.OurTypeWithDependencies));

      It should_return_the_greediest = () =>
        result.ShouldEqual(greediest_ctor);

      static ConstructorInfo result;
      static ConstructorInfo greediest_ctor;
    }
  }
}