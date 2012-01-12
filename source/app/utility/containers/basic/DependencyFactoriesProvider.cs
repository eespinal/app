using System;
using app.utility.containers.core;

namespace app.utility.containers.basic
{
  public class DependencyFactoriesProvider : ICreateDependencyFactories
  {
    IFetchDependencies container;
    IPickTheCtorOnTheType ctor_picker;

    public DependencyFactoriesProvider(IFetchDependencies container, IPickTheCtorOnTheType ctor_picker)
    {
      this.container = container;
      this.ctor_picker = ctor_picker;
    }

    public ICreateOneType create_automatic_factory_for(Type type)
    {
      return new AutomaticDependencyFactory(container, ctor_picker, type);
    }

    public ICreateOneType create_specific_factory_for(object instance)
    {
      return new SimpleFactory(() => instance);
    }
  }
}