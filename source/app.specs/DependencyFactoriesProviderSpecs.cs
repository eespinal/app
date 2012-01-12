using System.Data;
using System.Data.SqlClient;
using Machine.Specifications;
using app.utility.containers.basic;
using app.utility.containers.core;
using developwithpassion.specifications.extensions;
using developwithpassion.specifications.rhinomocks;

namespace app.specs
{
  [Subject(typeof(DependencyFactoriesProvider))]
  public class DependencyFactoriesProviderSpecs
  {
    public abstract class concern : Observes<ICreateDependencyFactories,
                                      DependencyFactoriesProvider>
    {
    }

    public class when_creating_a_dependency_factory : concern
    {
      public class for_automatic_creation
      {
        Establish c = () =>
        {
          the_container = depends.on<IFetchDependencies>();
          ctor_picker = depends.on<IPickTheCtorOnTheType>();
        };

        Because b = () =>
          result = sut.create_automatic_factory_for(typeof(SomeType));

        It should_return_an_automatic_dependency_factory_created_with_the_correct_details = () =>
        {
          var item = result.ShouldBeAn<AutomaticDependencyFactory>();
          item.container.ShouldEqual(the_container);
          item.constructor_picker.ShouldEqual(ctor_picker);
          item.type_that_i_create.ShouldEqual(typeof(SomeType));
        };

        static ICreateOneType result;
        static IFetchDependencies the_container;
        static IPickTheCtorOnTheType ctor_picker;
      }
      public class for_instance_creation
      {
        Establish c = () =>
        {
          instance = new SqlConnection();
        };

        Because b = () =>
          result = sut.create_specific_factory_for(instance);

        It should_return_a_specific_factory_to_return_the_instance = () =>
        {
          var item = result.ShouldBeAn<SimpleFactory>();
          item.create().ShouldEqual(instance);
        };

        static ICreateOneType result;
        static IDbConnection instance;
      }
    }

    public class SomeType
    {
    }
  }
}