using System.Web;
using app.utility;
using app.utility.containers;
using app.web.core.stubs;

namespace app.web.core.aspnet
{
  public class ASPHandler : IHttpHandler
  {
    IProcessRequests front_controller;
    ICreateRequests request_factory;

    public ASPHandler(IProcessRequests front_controller, ICreateRequests request_factory)
    {
      this.front_controller = front_controller;
      this.request_factory = request_factory;
    }

    public ASPHandler():this(Container.fetch.an<IProcessRequests>(),Container.fetch.an<ICreateRequests>())
    {
    }

    public void ProcessRequest(HttpContext context)
    {
      front_controller.process(request_factory.create_request_from(context));
    }

    public bool IsReusable
    {
      get { return true; }
    }
  }
}