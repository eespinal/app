using System;
using System.Collections.Generic;
using app.utility.containers.basic;

namespace app.tasks.startup
{
  public class StartupFacilities : IProvideStartupFacilities
  {
    IList<ICreateASingleDependency> dependencies;
    ICreateDependencyFactories factories_provider;
    ICreateTypeMatchers type_match_factory;

    public StartupFacilities(IList<ICreateASingleDependency> dependencies, ICreateDependencyFactories factories_provider,
                             ICreateTypeMatchers type_match_factory)
    {
      this.dependencies = dependencies;
      this.factories_provider = factories_provider;
      this.type_match_factory = type_match_factory;
    }

    public void register_factory_for<Contract, Implementation>() where Implementation : Contract
    {
      dependencies.Add(new DependencyFactory(
                         factories_provider.create_automatic_factory_for(typeof(Implementation)),
                         type_match_factory.create_type_matcher_for(typeof(Contract))));
    }

    public void register_factory_for<Contract>()
    {
      throw new NotImplementedException();
    }

    public void register_instance_for<Contract>(Contract instance)
    {
      throw new NotImplementedException();
    }
  }
}