using System.Web;
using app.web.application.catalogbrowing;

namespace app.web.core.stubs
{
  public class StubRequestFactory : ICreateRequests
  {
    public IProvideDetailsToCommands create_request_from(HttpContext a_context)
    {
      return new StubRequest();
    }

    class StubRequest : IProvideDetailsToCommands
    {
      public InputModel map<InputModel>()
      {
        object item = new Department();
        return (InputModel) item;
      }
    }
  }
}