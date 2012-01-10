using System.Web;

namespace app.web.core
{
  public interface ICreateRequests
  {
    IProvideDetailsToCommands create_request_from(HttpContext a_context);
  }
}