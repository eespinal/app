using System;

namespace app.utility.containers.basic
{
  public interface IFindFactoriesForDependencies
  {
    ICreateASingleDependency get_factory_that_can_create(Type type);
  }
}