using System;

namespace app.utility.containers
{
  public interface ICreateASingleDependency
  {
    object create();
    bool can_create(Type dependencyType);
  }
}