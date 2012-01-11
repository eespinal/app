using app.web.core;

namespace app.web.application.catalogbrowing
{
  public class ViewTheInformationInTheStore<Report> : ISupportAStory
  {
    private IDisplayReports display_engine;
    private IGetReports<Report> report_mapping;

    public ViewTheInformationInTheStore(IDisplayReports displayEngine, IGetReports<Report> reportMapping)
    {
      display_engine = displayEngine;
      report_mapping = reportMapping;
    }

    public void process(IProvideDetailsToCommands the_request)
    {
      display_engine.display(report_mapping.get_report(the_request));
    }
  }
}