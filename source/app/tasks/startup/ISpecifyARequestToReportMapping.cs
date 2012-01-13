using app.web.application.catalogbrowing;

namespace app.tasks.startup
{
  public class ViewingTheMainDepartments :
    ISpecifyARequestToReportMapping<ViewTheMainDepartmentsRequest, GetTheMainDepartments>
  {
    
  }
  public interface ISpecifyARequestToReportMapping<RequestType,ReportType>
  {
     
  }
}