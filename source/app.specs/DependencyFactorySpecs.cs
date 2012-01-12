using System;
using Machine.Specifications;
using app.utility.containers.basic;
using developwithpassion.specifications.rhinomocks;
using developwithpassion.specifications.extensions;

namespace app.specs
{
  [Subject(typeof(DependencyFactory))]
  public class DependencyFactorySpecs
  {
    public abstract class concern : Observes<ICreateASingleDependency,
                                      DependencyFactory>
    {
    }

    public class when_determining_if_it_can_create_a_type : concern
    {
      Establish c = () =>
      {
        type = typeof(int);
        depends.on<Predicate<Type>>(x => x == type);
      };

      Because b = () =>
        result = sut.can_create(type);

      It should_decide_using_its_type_criteria = () =>
        result.ShouldBeTrue();

      static bool result;
      static Type the_type;
      static Type type;
    }
    public class when_creating_a_dependency : concern
    {
      Establish c = () =>
      {
        the_item = new SomeItem();
        real_factory = depends.on<ICreateOneType>();
        real_factory.setup(x => x.create()).Return(the_item);
      };

      Because b = () =>
        result = sut.create();

      It should_return_the_item_created_by_the_specific_item_factory = () =>
        result.ShouldEqual(the_item);

      static object result;
      static SomeItem the_item;
      static ICreateOneType real_factory;
    }

    public class SomeItem
    {
    }
  }
}