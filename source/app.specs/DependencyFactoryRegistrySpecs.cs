using System;
using System.Collections.Generic;
using System.Linq;
using Machine.Specifications;
using app.utility.containers;
using developwithpassion.specifications.extensions;
using developwithpassion.specifications.rhinomocks;

namespace app.specs
{
  [Subject(typeof(DependencyFactoryRegistry))]
  public class DependencyFactoryRegistrySpecs
  {
    public abstract class concern : Observes<IFindFactoriesForDependencies,
                                      DependencyFactoryRegistry>
    {
    }

    public class when_finding_a_factory : concern
    {
      public class and_it_has_the_factory
      {
        Establish c = () =>
        {
          all_factories  = Enumerable.Range(1, 100).Select(x => fake.an<ICreateASingleDependency>()).ToList();
          factory_that_can_create = fake.an<ICreateASingleDependency>();
          dependency_type = typeof(int);
          all_factories.Add(factory_that_can_create);

          factory_that_can_create.setup(x => x.can_create(dependency_type)).Return(true);
          depends.on<IEnumerable<ICreateASingleDependency>>(all_factories);
        };

        Because b = () =>
          result = sut.get_factory_that_can_create(dependency_type);

        It should_return_the_factory_that_can_create_the_dependency = () =>
          result.ShouldEqual(factory_that_can_create);

        static ICreateASingleDependency result;
        static ICreateASingleDependency factory_that_can_create;
        static Type dependency_type;
        static List<ICreateASingleDependency> all_factories;

      }
      public class and_it_does_not_have_the_factory
      {
        Establish c = () =>
        {
          all_factories  = Enumerable.Range(1, 100).Select(x => fake.an<ICreateASingleDependency>()).ToList();
          factory_that_can_create = fake.an<ICreateASingleDependency>();
          the_exception = new Exception();
          dependency_type = typeof(int);
          depends.on<IEnumerable<ICreateASingleDependency>>(all_factories);
          depends.on<MissingDependencyFactory>(x =>
          {
            x.ShouldEqual(dependency_type);
            return the_exception;
          });
        };

        Because b = () =>
          spec.catch_exception(() => sut.get_factory_that_can_create(dependency_type));

        It should_throw_the_exception_create_by_the_factory_missing_exception_factory = () =>
          spec.exception_thrown.ShouldEqual(the_exception);

        static ICreateASingleDependency result;
        static ICreateASingleDependency factory_that_can_create;
        static Type dependency_type;
        static List<ICreateASingleDependency> all_factories;
        static Exception the_exception;
      }
    }
  }
}