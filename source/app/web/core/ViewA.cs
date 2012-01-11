namespace app.web.core
{
  public class ViewA<Report> : ISupportAStory
  {
    IDisplayReports display_engine;
    IFetchA<Report> report_query;

    public ViewA(IDisplayReports displayEngine, IFetchA<Report> report_query)
    {
      display_engine = displayEngine;
      this.report_query = report_query;
    }

    public void process(IProvideDetailsToCommands the_request)
    {
      display_engine.display(report_query.fetch_using(the_request));
    }
  }
}