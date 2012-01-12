using System;
using System.Collections.Generic;
using Machine.Specifications;
using app.tasks.startup;
using app.utility.containers.basic;
using developwithpassion.specifications.rhinomocks;
using developwithpassion.specifications.extensions;
using System.Linq;

namespace app.specs
{
  [Subject(typeof(StartupFacilities))]
  public class StartupFacilitiesSpecs
  {
    public abstract class concern : Observes<IProvideStartupFacilities, StartupFacilities>
    {
    }

    public class when_iterated:concern
    {
      Establish c = () =>
      {
        IList<ICreateASingleDependency> items = Enumerable.Range(1,100).Select(x => fake.an<ICreateASingleDependency>()).ToList();
        depends.on(items);
      };
      Because b = () =>
        result = sut;

      It should_return_all_of_its_factories = () =>
        result.Count().ShouldEqual(100);

      static IEnumerable<ICreateASingleDependency> result;


    }
    public class when_registering_a_factory : concern
    {
      public class by_contract_only
      {
        Establish c = () =>
        {
          matcher = x => true;
          factories_provider = depends.on<ICreateDependencyFactories>();
          type_matcher_factory = depends.on<ICreateTypeMatchers>();
          factories = new List<ICreateASingleDependency>();
          the_factory = fake.an<ICreateOneType>();
          factories_provider.setup(x => x.create_automatic_factory_for(typeof(AnImplementation))).Return(the_factory);
          type_matcher_factory.setup(x => x.create_type_matcher_for(typeof(AnImplementation)))
            .Return(matcher);

          depends.on(factories);
        };
        Because b = () =>
          sut.register_factory_for<AnImplementation>();

        It should_add_an_automatic_factory_created_using_the_correct_registration_mechanism = () =>
        {
          var created = factories.First().ShouldBeAn<DependencyFactory>();
          created.real_factory.ShouldEqual(the_factory);
          created.type_match_condition.ShouldEqual(matcher);
        };

        static IList<ICreateASingleDependency> factories;
        static ICreateOneType the_factory;
        static ICreateDependencyFactories factories_provider;
        static ICreateTypeMatchers type_matcher_factory;
        static Predicate<Type> matcher;
      }
      public class by_contract_and_implementation
      {
        Establish c = () =>
        {
          matcher = x => true;
          factories_provider = depends.on<ICreateDependencyFactories>();
          type_matcher_factory = depends.on<ICreateTypeMatchers>();
          factories = new List<ICreateASingleDependency>();
          the_factory = fake.an<ICreateOneType>();
          factories_provider.setup(x => x.create_automatic_factory_for(typeof(AnImplementation))).Return(the_factory);
          type_matcher_factory.setup(x => x.create_type_matcher_for(typeof(IAmAContract)))
            .Return(matcher);

          depends.on(factories);
        };
        Because b = () =>
          sut.register_factory_for<IAmAContract, AnImplementation>();

        It should_add_an_automatic_factory_created_using_the_correct_registration_mechanism = () =>
        {
          var created = factories.First().ShouldBeAn<DependencyFactory>();
          created.real_factory.ShouldEqual(the_factory);
          created.type_match_condition.ShouldEqual(matcher);
        };

        static IList<ICreateASingleDependency> factories;
        static ICreateOneType the_factory;
        static ICreateDependencyFactories factories_provider;
        static ICreateTypeMatchers type_matcher_factory;
        static Predicate<Type> matcher;
      }
      public class by_contract_and_instance
      {
        Establish c = () =>
        {
          matcher = x => true;
          instance = new AnImplementation();
          factories_provider = depends.on<ICreateDependencyFactories>();
          type_matcher_factory = depends.on<ICreateTypeMatchers>();
          factories = new List<ICreateASingleDependency>();
          the_factory = fake.an<ICreateOneType>();
          factories_provider.setup(x => x.create_specific_factory_for(instance)).Return(the_factory);
          type_matcher_factory.setup(x => x.create_type_matcher_for(typeof(IAmAContract)))
            .Return(matcher);

          depends.on(factories);
        };
        Because b = () =>
          sut.register_instance_for<IAmAContract>(instance);

        It should_add_an_explicit_factory_created_using_the_correct_registration_mechanism = () =>
        {
          var created = factories.First().ShouldBeAn<DependencyFactory>();
          created.real_factory.ShouldEqual(the_factory);
          created.type_match_condition.ShouldEqual(matcher);
        };

        static IList<ICreateASingleDependency> factories;
        static ICreateOneType the_factory;
        static ICreateDependencyFactories factories_provider;
        static ICreateTypeMatchers type_matcher_factory;
        static Predicate<Type> matcher;
        static AnImplementation instance;
      }

    }

    public class AnImplementation:IAmAContract
    {
    }

    public interface IAmAContract
    {
    }
  }
}