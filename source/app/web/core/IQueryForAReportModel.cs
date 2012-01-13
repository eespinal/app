namespace app.web.core
{
  public interface IQueryForAReportModel<out ReportModel>
  {
    ReportModel fetch_using(IProvideDetailsToCommands request);
  }
}