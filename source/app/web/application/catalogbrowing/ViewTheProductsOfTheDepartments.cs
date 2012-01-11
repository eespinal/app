using app.utility;
using app.web.application.catalogbrowing.stubs;
using app.web.core;
using app.web.core.stubs;

namespace app.web.application.catalogbrowing
{
  public class ViewTheProductsOfTheDepartments : ISupportAStory
  {

    IGetEntities entity_repository;
    IDisplayReports display_engine;

    public ViewTheProductsOfTheDepartments() : this(Stub.with<StubEntityRepository>(), Stub.with<StubDisplayEngine>())
    {
    }

    public ViewTheProductsOfTheDepartments(IGetEntities _entityRepository, IDisplayReports display_engine)
    {
      this.entity_repository = _entityRepository; 
      this.display_engine = display_engine;
    }    
    
    public void process(IProvideDetailsToCommands the_request)
    {
      display_engine.display(entity_repository.get_products_of(the_request.map<Department>()));
    }
  }
}