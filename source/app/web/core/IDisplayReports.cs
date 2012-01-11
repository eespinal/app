namespace app.web.core
{
  public interface IDisplayReports
  {
    void display<Report>(Report report);
  }

  public interface IGetReports<ReportType>
  {
    ReportType get_report(IProvideDetailsToCommands theRequest);
  }
}