using System;

namespace app.utility.containers.basic
{
  public class TypeMatcherFactory :ICreateTypeMatchers
  {
    public Predicate<Type> create_type_matcher_for(Type type)
    {
      return instance => instance == type;
    }
  }
}