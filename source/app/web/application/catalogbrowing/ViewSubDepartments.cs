using app.utility;
using app.web.application.catalogbrowing.stubs;
using app.web.core;
using app.web.core.stubs;

namespace app.web.application.catalogbrowing
{
  public class ViewSubDepartments : ISupportAStory
  {
    IGetEntities _entityRepository;
    IDisplayReports display_engine;

    public ViewSubDepartments() : this(Stub.with<StubEntityRepository>(), Stub.with<StubDisplayEngine>())
    {
    }

    public ViewSubDepartments(IGetEntities _entityRepository, IDisplayReports display_engine)
    {
      this._entityRepository = _entityRepository;
      this.display_engine = display_engine;
    }

    public void process(IProvideDetailsToCommands the_request)
    {
      display_engine.display(_entityRepository.get_sub_departments_of(the_request.map<Department>()));
    }
  }
}