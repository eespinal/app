using System;

namespace app.tasks.startup
{
  public delegate Exception StartupConventionNotFollowedExceptionFactory(Type type_that_does_not_follow_convention);
}