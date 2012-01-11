namespace app.web.core.aspnet
{
  public class WebFormDisplayEngine : IDisplayReports
  {
    ICreateViews view_factory;

    public WebFormDisplayEngine(ICreateViews view_factory)
    {
      this.view_factory = view_factory;
    }

    public void display<Report>(Report report)
    {
      view_factory.create_view_that_can_render(report);
    }
  }
}