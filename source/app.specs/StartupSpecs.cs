using Machine.Specifications;
using app.tasks.startup;
using app.utility.containers.core;
using app.web.core;
using developwithpassion.specifications.extensions;
using developwithpassion.specifications.rhinomocks;

namespace app.specs
{
  [Subject(typeof(StartupSpecs))]
  public class StartupSpecs
  {
    public abstract class concern : Observes
    {
    }

    public class when_the_application_has_finished_startup : concern
    {
      Because b = () =>
        Startup.run();

      It should_be_able_to_access_key_services =
        () => Container.fetch.an<IProcessRequests>().ShouldBeAn<FrontController>();
    }
  }
}