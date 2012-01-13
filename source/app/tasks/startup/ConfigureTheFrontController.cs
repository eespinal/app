﻿using System;
using System.Collections.Generic;
using System.Web;
using System.Web.Compilation;
using app.utility.containers.core;
using app.utility.logger;
using app.utility.logger.basic;
using app.utility.logger.core;
using app.web.core;
using app.web.core.aspnet;
using app.web.core.rendering;
using app.web.core.requestmatching;
using app.web.core.routing;
using app.web.core.stubs;

namespace app.tasks.startup
{
  public class ConfigureTheFrontController : IRunAStartupStep
  {
    IProvideStartupFacilities startup_facility;

    public ConfigureTheFrontController(IProvideStartupFacilities startup_facility)
    {
      this.startup_facility = startup_facility;
    }

    public void run()
    {
      startup_facility.register_factory_for<IBuildRequestMatchers, StubRequestMatchBuilder>();

      var routes = new RouteTable(Container.fetch.an<IBuildRequestMatchers>(),
                                  new List<IProcessASingleRequest>(), Container.fetch);

      var path_registry = new PathRegistry(StartupItems.exception_factories.path_already_registered);

      startup_facility.register_factory_for<IProcessRequests, FrontController>();
      startup_facility.register_factory_for<IFindCommands, CommandRegistry>();

      startup_facility.register_instance_for<IEnumerable<IProcessASingleRequest>>(routes);
      startup_facility.register_instance_for<IRegisterRoutes>(routes);

      startup_facility.register_instance_for<WebFormFactory>(BuildManager.CreateInstanceFromVirtualPath);
      startup_facility.register_instance_for<GetTheActiveHttpContext>(() => HttpContext.Current);
      startup_facility.register_instance_for<MessageWritter>(Console.WriteLine);
      startup_facility.register_factory_for<ILog, TextWriterLogger>();
      startup_facility.register_factory_for<IDisplayReports, WebFormDisplayEngine>();
      startup_facility.register_factory_for<IProcessASingleRequest, StubMissingCommand>();
      startup_facility.register_factory_for<ICreateRequests, StubRequestFactory>();
      startup_facility.register_factory_for<ICreateViews, WebFormViewFactory>();

      startup_facility.register_instance_for<IFindPathsToTemplates>(path_registry);
      startup_facility.register_instance_for<IRegisterPaths>(path_registry);
    }
  }
}
