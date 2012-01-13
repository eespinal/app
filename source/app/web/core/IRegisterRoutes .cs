using System.Collections.Generic;

namespace app.web.core
{
  public interface IRegisterRoutes : IEnumerable<IProcessASingleRequest>
  {
    void a_report<RequestType, Query,ReportModel>() where Query:IFetchA<ReportModel>; 
  }
}