using System;
using System.Collections.Generic;
using Machine.Specifications;
using app.utility.containers;
using developwithpassion.specifications.extensions;
using developwithpassion.specifications.rhinomocks;

namespace app.specs
{
  [Subject(typeof(DependenciesFactoryFinder))]
  public class DependenciesFactoryFinderSpecs
  {
    public abstract class concern : Observes<IFindFactoriesForDependencies,
                                      DependenciesFactoryFinder>
    {
    }

    public class when_getting_asked_to_find_a_factory_for_a_dependency : concern
    {
        Establish c = () =>
                        {
                          all_factories = depends.on<List<ICreateASingleDependency>>();
                          the_factory = fake.an<ICreateASingleDependency>();
                          dependency_type = fake.an<Type>();

                          all_factories.setup(x => x.Find(y=>y.for_type(dependency_type))).Return(the_factory);
                        };

        Because b = () =>
          result = sut.get_factory_that_can_create(dependency_type);

        It should_return_the_factory_that_can_create_the_dependency = () =>
          result.ShouldEqual(the_factory); 

        private static ICreateASingleDependency result;
        private static ICreateASingleDependency the_factory;
        private static Type dependency_type;
      private static List<ICreateASingleDependency> all_factories;
    }
  }
}