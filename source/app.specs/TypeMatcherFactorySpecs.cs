using System;
using System.Data.SqlClient;
using Machine.Specifications;
using app.utility.containers.basic;
using developwithpassion.specifications.rhinomocks;

namespace app.specs
{
  [Subject(typeof(TypeMatcherFactory))]
  public class TypeMatcherFactorySpecs
  {
    public abstract class concern : Observes<ICreateTypeMatchers,
                                      TypeMatcherFactory>
    {
    }

    public class when_creating_type_matchers : concern
    {
      public class and_creating_one_that_matches_a_contract_type
      {
        Because b = () =>
          result = sut.create_type_matcher_for(typeof(SqlConnection));

        It should_return_a_matcher_that_sees_if_the_instance_is_the_contract_type = () =>
          result(typeof(SqlConnection)).ShouldBeTrue();

        static Predicate<Type> result;
      }
    }
  }
}