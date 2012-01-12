using System;

namespace app.utility.containers
{
  public class DependenciesFactoryFinder : IFindFactoriesForDependencies
  {
    public ICreateASingleDependency get_factory_that_can_create(Type type)
    {
      throw new NotImplementedException();
    }
  }
}