﻿using app.utility;
using app.web.application.catalogbrowing.stubs;
using app.web.core;
using app.web.core.stubs;

namespace app.web.application.catalogbrowing
{
  public class ViewTheMainDepartmentsInTheStore : ISupportAStory
  {
    IGetEntities _entityRepository;
    IDisplayReports display_engine;

    public ViewTheMainDepartmentsInTheStore():this(Stub.with<StubEntityRepository>(),
      Stub.with<StubDisplayEngine>())
    {
    }

    public ViewTheMainDepartmentsInTheStore(IGetEntities _entityRepository, IDisplayReports display_engine)
    {
      this._entityRepository = _entityRepository;
      this.display_engine = display_engine;
    }

    public void process(IProvideDetailsToCommands the_request)
    {
      display_engine.display(_entityRepository.get_the_main_departments());
    }
  }
}