using System;

namespace app.utility.containers.basic
{
  public interface ICreateTypeMatchers
  {
    Predicate<Type> create_type_matcher_for(Type type);
  }
}