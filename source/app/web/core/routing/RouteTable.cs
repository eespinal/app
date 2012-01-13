using System.Collections;
using System.Collections.Generic;
using app.utility.containers.core;
using app.web.core.rendering;
using app.web.core.requestmatching;

namespace app.web.core.routing
{
  public class RouteTable : IRegisterRoutes
  {
    IBuildRequestMatchers match;
    IFetchDependencies container;
    IList<IProcessASingleRequest> routes;

    public RouteTable(IBuildRequestMatchers match,IList<IProcessASingleRequest> routes, IFetchDependencies container)
    {
      this.match = match;
      this.routes = routes;
      this.container = container;
    }

    public IEnumerator<IProcessASingleRequest> GetEnumerator()
    {
      return routes.GetEnumerator();
    }

    public void a_report<RequestType, Query, ReportModel>() where Query : IFetchA<ReportModel>
    {
      var item = new ViewA<ReportModel>(container.an<IDisplayReports>(),
                                        container.an<Query>());

      routes.Add(new RequestHandler(match.made_for<RequestType>(), item));
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
      return GetEnumerator();
    }
  }
}