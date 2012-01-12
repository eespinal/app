using System;

namespace app.utility.containers.basic
{
  public class SimpleFactory : ICreateOneType
  {
    Func<object> factory;

    public SimpleFactory(Func<object> factory)
    {
      this.factory = factory;
    }

    public object create()
    {
      return factory();
    }
  }
}