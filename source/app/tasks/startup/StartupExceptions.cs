using System;
using app.utility.containers.basic;

namespace app.tasks.startup
{
  public class StartupExceptions
  {
    public static MissingDependencyFactory dependency_factory_not_registered = (type) =>
    {
      throw new NotImplementedException(string.Format("The type {0} has no factory to create it", type.Name));
    };

    public static ItemCreationExceptionFactory dependency_creation_exception = (type, inner) =>
    {
      throw new NotImplementedException(string.Format("The type {0} had errors when being created", type.Name));
    };
  }
}