using System.Web;
using System.Web.Compilation;
using app.utility;
using app.web.core.stubs;

namespace app.web.core.aspnet
{
  public class WebFormViewFactory : ICreateViews
  {
    IFindPathsToTemplates template_path_registry;
    WebFormFactory web_form_factory;

    public WebFormViewFactory():this(Stub.with<StubPathRegistry>(),
      BuildManager.CreateInstanceFromVirtualPath)
    {
    }

    public WebFormViewFactory(IFindPathsToTemplates template_path_registry, WebFormFactory webFormFactory)
    {
      this.template_path_registry = template_path_registry;
      this.web_form_factory = webFormFactory;
    }

    public IHttpHandler create_view_that_can_render<ReportModel>(ReportModel report)
    {
      var view_that_can_render =
        web_form_factory(template_path_registry.get_path_to_template_for<ReportModel>(), typeof(IDisplayA<ReportModel>))
          as IDisplayA<ReportModel>;
      view_that_can_render.report = report;
      return view_that_can_render;
    }
  }
}