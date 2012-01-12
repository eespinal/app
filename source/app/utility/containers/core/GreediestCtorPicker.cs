using System;
using System.Reflection;
using System.Linq;

namespace app.utility.containers.core
{
  public class GreediestCtorPicker : IPickTheCtorOnTheType
  {
    public ConstructorInfo get_applicable_ctor_on(Type type)
    {
      return type.GetConstructors().OrderByDescending(x => x.GetParameters().Count()).First();
    }
  }
}