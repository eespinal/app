using Machine.Specifications;
using app.web.core;
using app.web.core.aspnet;
using developwithpassion.specifications.extensions;
using developwithpassion.specifications.rhinomocks;

namespace app.specs
{
  [Subject(typeof(WebFormDisplayEngine))]
  public class WebFormDisplayEngineSpecs
  {
    public abstract class concern : Observes<IDisplayReports,
                                      WebFormDisplayEngine>
    {
    }

    public class when_displaying_a_report : concern
    {
      Establish c = () =>
      {
        report = new AReport();
        view_factory = depends.on<ICreateViews>();
      };
      Because b = () =>
        sut.display(report);

      It should_create_the_view_that_can_display_the_report = () =>
        view_factory.received(x => x.create_view_that_can_render(report));

      static ICreateViews view_factory;
      static AReport report;
    }

    public class AReport
    {
    }
  }
}