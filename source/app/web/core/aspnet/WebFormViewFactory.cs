using System.Web;

namespace app.web.core.aspnet
{
  public class WebFormViewFactory : ICreateViews
  {
    public IHttpHandler create_view_that_can_render<ReportModel>(ReportModel report)
    {
      throw new System.NotImplementedException();
    }
  }
}