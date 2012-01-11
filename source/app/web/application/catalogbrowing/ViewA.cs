using app.utility;
using app.web.core;
using app.web.core.stubs;

namespace app.web.application.catalogbrowing
{
  public class ViewA<Report> : ISupportAStory
  {
    IDisplayReports display_engine;
    IFetchA<Report> report_query;

    public ViewA(IFetchA<Report>  query):this(Stub.with<StubDisplayEngine>(),query)
    {
    }

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