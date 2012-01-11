using app.utility;
using app.web.application.catalogbrowing.stubs;
using app.web.core;
using app.web.core.stubs;

namespace app.web.application.catalogbrowing
{
  public class ViewSubDepartments : ISupportAStory
  {
    IFindInformationInTheStore entity_repository;
    IDisplayReports display_engine;

    public ViewSubDepartments() : this(Stub.with<StubStoreCatalog>(), Stub.with<StubDisplayEngine>())
    {
    }

    public ViewSubDepartments(IFindInformationInTheStore _entityRepository, IDisplayReports display_engine)
    {
      this.entity_repository = _entityRepository;
      this.display_engine = display_engine;
    }

    public void process(IProvideDetailsToCommands the_request)
    {
      display_engine.display(entity_repository.get_sub_departments_of(the_request.map<Department>()));
    }
  }
}