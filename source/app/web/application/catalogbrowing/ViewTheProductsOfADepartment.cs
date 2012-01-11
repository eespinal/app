using app.utility;
using app.web.application.catalogbrowing.stubs;
using app.web.core;
using app.web.core.stubs;

namespace app.web.application.catalogbrowing
{
  public class ViewTheProductsOfADepartment : ISupportAStory
  {
    IFindInformationInTheStore entity_repository;
    IDisplayReports display_engine;

    public ViewTheProductsOfADepartment() : this(Stub.with<StubStoreCatalog>(), Stub.with<StubDisplayEngine>())
    {
    }

    public ViewTheProductsOfADepartment(IFindInformationInTheStore _entityRepository, IDisplayReports display_engine)
    {
      this.entity_repository = _entityRepository;
      this.display_engine = display_engine;
    }

    public void process(IProvideDetailsToCommands the_request)
    {
      display_engine.display(entity_repository.get_products_of(the_request.map<Department>()));
    }
  }

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