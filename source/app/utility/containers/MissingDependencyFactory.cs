using System;

namespace app.utility.containers
{
  public delegate Exception MissingDependencyFactory(Type type_that_has_no_factory);
}