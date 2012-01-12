using System;
using System.Collections.Generic;
using System.Linq;
using app.utility.containers.core;

namespace app.utility.containers.basic
{
  public class AutomaticDependencyFactory : ICreateOneType
  {
      private readonly IFetchDependencies dependencies_fetcher;
      private readonly IPickTheCtorOnTheType constructor_picker;
      private readonly Type type_that_i_create;

      public AutomaticDependencyFactory(IFetchDependencies dependencies_fetcher,IPickTheCtorOnTheType constructor_picker,Type type_that_i_create)
      {
          this.dependencies_fetcher = dependencies_fetcher;
          this.constructor_picker = constructor_picker;
          this.type_that_i_create = type_that_i_create;
      }

      public object create()
      {
          var constructor = constructor_picker.get_applicable_ctor_on(type_that_i_create);
          var constructor_dependencies = constructor.GetParameters();

          return Activator.CreateInstance(type_that_i_create, constructor_dependencies.Select(constructorDependency => dependencies_fetcher.an(constructorDependency.ParameterType)).ToArray());
      }
  }
}