namespace app.web.core.aspnet
{
  public class WebFormDisplayEngine : IDisplayReports
  {
      readonly ICreateViews createViews;

      public WebFormDisplayEngine(ICreateViews createViews)
      {
          this.createViews = createViews;
      }

      public void display<Report>(Report report)
      {
          createViews.create_view_that_can_render(report);
      }
  }
}