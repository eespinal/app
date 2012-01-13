using System.Collections;
using System.Collections.Generic;
using app.utility.containers.basic;

namespace app.tasks.startup
{
  public class StartupFacilities : IProvideStartupFacilities
  {
    IList<ICreateASingleDependency> all_factories;
    ICreateDependencyFactories factories_provider;
    ICreateTypeMatchers type_match_factory;

    public StartupFacilities(IList<ICreateASingleDependency> all_factories, ICreateDependencyFactories factories_provider,
                             ICreateTypeMatchers type_match_factory)
    {
      this.all_factories = all_factories;
      this.factories_provider = factories_provider;
      this.type_match_factory = type_match_factory;
    }

    public void register_factory_for<Contract, Implementation>() where Implementation : Contract
    {
      register_factory_for<Contract>(factories_provider.create_automatic_factory_for(typeof(Implementation)));
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
      return GetEnumerator();
    }

    public IEnumerator<ICreateASingleDependency> GetEnumerator()
    {
      return all_factories.GetEnumerator();
    }

    public void register_factory_for<Contract>()
    {
      register_factory_for<Contract, Contract>();
    }

    public void register_instance_for<Contract>(Contract instance)
    {
      register_factory_for<Contract>(factories_provider.create_specific_factory_for(instance));
    }


    void register_factory_for<Contract>(ICreateOneType factory)
    {
      all_factories.Add(new DependencyFactory(factory,
                                             type_match_factory.create_type_matcher_for(typeof(Contract))));
    }
  }
}