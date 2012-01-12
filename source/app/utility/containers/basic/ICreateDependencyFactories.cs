using System;

namespace app.utility.containers.basic
{
  public interface ICreateDependencyFactories
  {
    ICreateOneType create_automatic_factory_for(Type type);
    ICreateOneType create_specific_factory_for(object instance);
  }
}