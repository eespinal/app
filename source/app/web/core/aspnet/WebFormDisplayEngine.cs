using System.Web;

namespace app.web.core.aspnet
{
  public class WebFormDisplayEngine : IDisplayReports
  {
    ICreateViews view_factory;
    GetTheActiveHttpContext current_context_resolver;

    public WebFormDisplayEngine(ICreateViews view_factory, GetTheActiveHttpContext current_context_resolver)
    {
      this.view_factory = view_factory;
      this.current_context_resolver = current_context_resolver;
    }

    public WebFormDisplayEngine():this(new WebFormViewFactory(),() => HttpContext.Current)
    {
    }

    public void display<Report>(Report report)
    {
      view_factory.create_view_that_can_render(report).ProcessRequest(current_context_resolver());
    }
  }
}