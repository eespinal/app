using System;
using System.Reflection;

namespace app.utility.containers.core
{
  public interface IPickTheCtorOnTheType
  {
    ConstructorInfo get_applicable_ctor_on(Type type);
  }
}