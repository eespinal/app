using System;
using System.Linq;
using app.utility.containers.core;

namespace app.utility.containers.basic
{
  public class AutomaticDependencyFactory : ICreateOneType
  {
    IFetchDependencies container;
    IPickTheCtorOnTheType constructor_picker;
    Type type_that_i_create;

    public AutomaticDependencyFactory(IFetchDependencies container, IPickTheCtorOnTheType constructor_picker,
                                      Type type_that_i_create)
    {
      this.container = container;
      this.constructor_picker = constructor_picker;
      this.type_that_i_create = type_that_i_create;
    }

    public object create()
    {
      var constructor = constructor_picker.get_applicable_ctor_on(type_that_i_create);
      var items = constructor.GetParameters().Select(x => container.an(x.ParameterType));
      return constructor.Invoke(items.ToArray());
    }
  }
}