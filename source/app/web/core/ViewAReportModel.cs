using app.web.core.rendering;

namespace app.web.core
{
  public class ViewAReportModel<ReportModel> : ISupportAStory
  {
    public IDisplayReports display_engine;
    public IQueryForAReportModel<ReportModel> report_query;

    public ViewAReportModel(IDisplayReports displayEngine, IQueryForAReportModel<ReportModel> report_query)
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