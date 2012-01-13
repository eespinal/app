using System.Collections;
using System.Collections.Generic;

namespace app.web.core
{
  public interface IRegisterRoutes : IEnumerable<IProcessASingleRequest>
  {
    void a_report<RequestType, Query,ReportModel>() where Query:IFetchA<ReportModel>; 
  }

    public class RegisterRoutes : IRegisterRoutes
    {
        RequestCriteria request_criteria;
        IProcessASingleRequest missing_command;
        IList<IProcessASingleRequest> process_a_single_request_list;

        public RegisterRoutes(RequestCriteria request_criteria, IProcessASingleRequest missing_command)
        {
            this.request_criteria = request_criteria;
            this.missing_command = missing_command;
            process_a_single_request_list = new List<IProcessASingleRequest>();
        }

        public IEnumerator<IProcessASingleRequest> GetEnumerator()
        {
          return  process_a_single_request_list.GetEnumerator();
        }

        public void a_report<RequestType, Query, ReportModel>() where Query : IFetchA<ReportModel>
        {
            process_a_single_request_list.Add(new RequestHandler(request_criteria,missing_command));
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}