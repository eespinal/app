using System;
using Machine.Specifications;
using app.utility.containers.basic;
using developwithpassion.specifications.rhinomocks;

namespace app.specs
{
  [Subject(typeof(SimpleFactory))]
  public class SimpleFactorySpecs
  {
    public abstract class concern : Observes<ICreateOneType,
                                      SimpleFactory>
    {
    }

    public class when_creating_an_instance : concern
    {
      Establish c = () =>
      {
        item = new TheItem();
        depends.on<Func<object>>(() => item);
      };

      Because b = () =>
        result = sut.create();

      It should_return_the_type_created_by_the_block = () =>
        result.ShouldEqual(item);

      static object result;
      static TheItem item;
    }

    public class TheItem
    {
    }
  }
}