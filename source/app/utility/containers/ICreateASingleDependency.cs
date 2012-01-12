using System;

namespace app.utility.containers
{
  public interface ICreateASingleDependency
  {
    object create();
    bool for_type(Type dependencyType);
  }
}