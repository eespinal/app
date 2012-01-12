using System;

namespace app.utility.containers.basic
{
  public class DependencyFactory:ICreateASingleDependency
  {
    ICreateOneType real_factory;
    Predicate<Type> type_match_condition;

    public DependencyFactory(ICreateOneType real_factory, Predicate<Type> type_match_condition)
    {
      this.real_factory = real_factory;
      this.type_match_condition = type_match_condition;
    }

    public object create()
    {
      return real_factory.create();
    }

    public bool can_create(Type dependency_type)
    {
      return type_match_condition(dependency_type);
    }
  }
}