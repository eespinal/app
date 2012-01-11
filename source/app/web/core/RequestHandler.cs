namespace app.web.core
{
  public class RequestHandler : IProcessASingleRequest
  {
    ISupportAStory application_feature;
    RequestCriteria request_criteria;

    public RequestHandler(RequestCriteria requestCriteria, ISupportAStory application_feature)
    {
      request_criteria = requestCriteria;
      this.application_feature = application_feature;
    }

    public void process(IProvideDetailsToCommands the_request)
    {
      application_feature.process(the_request);
    }

    public bool can_process(IProvideDetailsToCommands the_request)
    {
      return request_criteria(the_request);
    }
  }
}