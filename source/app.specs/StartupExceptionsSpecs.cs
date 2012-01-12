using System;
using Machine.Specifications;
using app.tasks.startup;
using developwithpassion.specifications.rhinomocks;

namespace app.specs
{
  [Subject(typeof(StartupExceptions))]
  public class StartupExceptionsSpecs
  {
    public abstract class concern : Observes
    {

    }

    public class when_accessing_a_startup_exception : concern
    {
      public class for_a_factory_not_registered
      {
        Because b = () =>
          spec.catch_exception(() => StartupExceptions.dependency_factory_not_registered(typeof(OurType)));

        It should_return_a_block_that_throws_an_exception_with_the_correct_information = () =>
        {
          var item = spec.exception_thrown;
          item.Message.ShouldContain(typeof(OurType).Name);
        };
           
      }
      public class for_a_dependency_creation_error
      {
        Establish c = () =>
        {
          the_exception = new Exception();
        };

        Because b = () =>
          spec.catch_exception(() => StartupExceptions.dependency_creation_exception(typeof(OurType), the_exception));

        It should_return_a_block_that_throws_an_exception_with_the_correct_information = () =>
        {
          var item = spec.exception_thrown;
          item.Message.ShouldContain(typeof(OurType).Name);
          item.InnerException.ShouldEqual(the_exception);
        };

        static Exception the_exception;
      }
        
  class OurType
  {
  }
    }
  }

}
