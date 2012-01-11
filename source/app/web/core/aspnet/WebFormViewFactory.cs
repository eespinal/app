using System.Web;
using System.Web.UI;

namespace app.web.core.aspnet
{
  public class WebFormViewFactory : ICreateViews
  {
    IFindPathsToTemplates template_path_registry;
      private readonly WebFormFactory webFormFactory;

      public WebFormViewFactory(IFindPathsToTemplates template_path_registry, WebFormFactory webFormFactory)
    {
        this.template_path_registry = template_path_registry;
        this.webFormFactory = webFormFactory;
    }

      public IHttpHandler create_view_that_can_render<ReportModel>(ReportModel report)
    {
      return webFormFactory(template_path_registry.get_path_to_template_for<ReportModel>(),typeof(Page)) as IHttpHandler;
    }
  }
}