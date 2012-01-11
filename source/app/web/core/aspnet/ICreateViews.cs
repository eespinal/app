using System.Web;

namespace app.web.core.aspnet
{
  public interface ICreateViews
  {
    IHttpHandler create_view_that_can_render<ReportModel>(ReportModel report);
  }
}