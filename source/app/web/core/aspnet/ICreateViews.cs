namespace app.web.core.aspnet
{
  public interface ICreateViews
  {
    void create_view_that_can_render<ReportModel>(ReportModel report);
  }
}