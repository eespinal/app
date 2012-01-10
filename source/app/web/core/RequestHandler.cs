namespace app.web.core
{
  public class RequestHandler:IProcessASingleRequest
  {
    private RequestCriteria request_criteria;

    public RequestHandler(RequestCriteria requestCriteria)
    {
      request_criteria = requestCriteria;
    }

    public void process(IProvideDetailsToCommands the_request)
    {
      throw new System.NotImplementedException();
    }

    public bool can_process(IProvideDetailsToCommands the_request)
    {
      return request_criteria(the_request);
    }
  }
}