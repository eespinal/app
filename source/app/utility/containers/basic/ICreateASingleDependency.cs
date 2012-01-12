using System;

namespace app.utility.containers.basic
{
  public interface ICreateASingleDependency : ICreateOneType
  {
    bool can_create(Type dependency_type);
  }
}