using System;
using Machine.Specifications;
using app.utility.containers;
using developwithpassion.specifications.extensions;
using developwithpassion.specifications.rhinomocks;

namespace app.specs
{
  [Subject(typeof(DependencyContainer))]
  public class DependencyContainerSpecs
  {
    public abstract class concern : Observes<IFetchDependencies,
                                      DependencyContainer>
    {
    }

    public class when_getting_a_dependency : concern
    {
      public class in_a_runtime_context
      {
        Establish c = () =>
        {
          the_item = fake.an<TheDependency>();
          factories = depends.on<IFindFactoriesForDependencies>();
          factory = fake.an<ICreateASingleDependency>();

          factories.setup(x => x.get_factory_that_can_create(typeof(TheDependency))).Return(factory);
          factory.setup(x => x.create()).Return(the_item);
        };

        Because b = () =>
          result = sut.an(typeof(TheDependency));

        It should_return_the_dependency_created_by_the_factory = () =>
          result.ShouldEqual(the_item);

        static object result;
        static TheDependency the_item;
        static ICreateASingleDependency factory;
        static IFindFactoriesForDependencies factories;
      }

      public class and_the_factory_successfully_creates_the_item
      {
        Establish c = () =>
        {
          the_item = fake.an<TheDependency>();
          factories = depends.on<IFindFactoriesForDependencies>();
          factory = fake.an<ICreateASingleDependency>();

          factories.setup(x => x.get_factory_that_can_create(typeof(TheDependency))).Return(factory);
          factory.setup(x => x.create()).Return(the_item);
        };

        Because b = () =>
          result = sut.an<TheDependency>();

        It should_return_the_dependency_created_by_the_factory = () =>
          result.ShouldEqual(the_item);

        static TheDependency result;
        static TheDependency the_item;
        static ICreateASingleDependency factory;
        static IFindFactoriesForDependencies factories;
      }

      public class and_the_factory_throws_an_exception_while_trying_to_create_the_item
      {
        Establish c = () =>
        {
          factories = depends.on<IFindFactoriesForDependencies>();
          factory = fake.an<ICreateASingleDependency>();
          exception = new Exception();
          new_exception = new Exception();
          depends.on<ItemCreationExceptionFactory>((type, inner) =>
          {
            inner.ShouldEqual(exception);
            type.ShouldEqual(typeof(TheDependency));
            return new_exception;
          });

          factories.setup(x => x.get_factory_that_can_create(typeof(TheDependency))).Return(factory);
          factory.setup(x => x.create()).Throw(exception);
        };

        Because b = () =>
          spec.catch_exception(() => sut.an<TheDependency>());

        It should_throw_the_exception_created_by_the_item_creation_exception_factory = () =>
          spec.exception_thrown.ShouldEqual(new_exception);

        static ICreateASingleDependency factory;
        static IFindFactoriesForDependencies factories;
        static Exception exception;
        static Exception new_exception;
      }
    }

    public class TheDependency
    {
    }
  }
}