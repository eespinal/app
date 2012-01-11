namespace app.web.core
{
  public interface IFetchA<ReportModel>
  {
    ReportModel fetch_using(IProvideDetailsToCommands request);
  }
}