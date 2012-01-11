using System.Web;

namespace app.web.core.aspnet
{
    public class WebFormDisplayEngine : IDisplayReports
    {
        readonly ICreateViews view_factory;
        readonly HttpContext context;

        public WebFormDisplayEngine(ICreateViews view_factory, HttpContext context)
        {
            this.view_factory = view_factory;
            this.context = context;
        }

        public void display<Report>(Report report)
        {
            var view = view_factory.create_view_that_can_render(report);
            view.ProcessRequest(context);
        }
    }
}