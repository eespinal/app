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
  class TheDependency
  {
  }
  }

}