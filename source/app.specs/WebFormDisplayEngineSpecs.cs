using System.Web;
using Machine.Specifications;
using app.specs.utility;
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
        view = fake.an<IHttpHandler>();
        view_factory = depends.on<ICreateViews>();
        the_current_context = ObjectFactory.web.create_http_context();
        depends.on(the_current_context);

        view_factory.setup(x => x.create_view_that_can_render(report)).Return(view);
      };

      Because b = () =>
        sut.display(report);

      It should_tell_the_view_to_render = () =>
        view.received(x => x.ProcessRequest(the_current_context));
        

      static ICreateViews view_factory;
      static AReport report;
      static IHttpHandler view;
      static HttpContext the_current_context;
    }

    public class AReport
    {
    }
  }
}