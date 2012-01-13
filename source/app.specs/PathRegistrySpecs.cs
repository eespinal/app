using System;
using System.Collections.Generic;
using Machine.Specifications;
using app.web.core.aspnet;
using developwithpassion.specifications.rhinomocks;

namespace app.specs
{
  [Subject(typeof(PathRegistrySpecs))]
  public class PathRegistrySpecs
  {
    public abstract class concern : Observes<IFindPathsToTemplates, PathRegistry>
    {
    }

    public abstract class concern_for_registration : Observes<IFindPathsToTemplates, PathRegistry>
    {
    }

    public class when_registering_a_path_to_a_view : concern_for_registration
    {
      public class that_has_not_already_been_registered
      {
        Establish c = () =>
        {
          all_paths = depends.on<IDictionary<Type, string>>(new Dictionary<Type, string>());
        };

        Because b = () =>
          sut.register_path_for_template<SomeReport>("blah");

        It should_add_the_path_to_the_list_of_paths = () =>
          all_paths[typeof(SomeReport)].ShouldEqual("blah");

        static string result;
        static string the_path;
        static IDictionary<Type, string> all_paths;
      }
      public class that_has_already_been_registered
      {
        Establish c = () =>
        {
          exception = new Exception();
          depends.on<IDictionary<Type, string>>(new Dictionary<Type, string>());
          sut_setup.run(x => x.register_path_for_template<SomeReport>("blah"));
          depends.on<TemplatePathAlreadyRegisteredExceptionFactory>(x =>
          {
            x.ShouldEqual(typeof(SomeReport));
            return exception;
          });
        };

        Because b = () =>
          spec.catch_exception(() => sut.register_path_for_template<SomeReport>("blah"));

        It should_throw_an_report_template_already_registered_exception = () =>
          spec.exception_thrown.ShouldEqual(exception);

        static Exception exception;
      }
    }

    public class when_finding_the_path_to_a_report_model : concern
    {
      Establish c = () =>
      {
        the_path = "bla";
        all_paths = depends.on<IDictionary<Type, string>>(new Dictionary<Type, string>());
        all_paths.Add(typeof(SomeReport), the_path);
      };

      Because b = () =>
        result = sut.get_path_to_template_for<SomeReport>();

      It should_return_the_path_from_the_dictionary = () =>
        result.ShouldEqual(the_path);

      static string result;
      static string the_path;
      static IDictionary<Type, string> all_paths;
    }

    public class SomeReport
    {
    }
  }
}