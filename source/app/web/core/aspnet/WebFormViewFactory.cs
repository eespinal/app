using System.Web;

namespace app.web.core.aspnet
{
  public class WebFormViewFactory : ICreateViews
  {
    IFindPathsToTemplates template_path_registry;

    public WebFormViewFactory(IFindPathsToTemplates template_path_registry)
    {
      this.template_path_registry = template_path_registry;
    }

    public IHttpHandler create_view_that_can_render<ReportModel>(ReportModel report)
    {
      template_path_registry.get_path_to_template_for<ReportModel>();
      return null;
    }
  }
}