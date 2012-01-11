namespace app.web.core
{
  public interface IGetReports<ReportType>
  {
    ReportType get_report(IProvideDetailsToCommands theRequest);
  }
}