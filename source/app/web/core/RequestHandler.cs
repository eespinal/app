namespace app.web.core
{
  public class RequestHandler : IProcessASingleRequest
  {
    public ISupportAStory application_feature;
    public RequestCriteria request_criteria;

    public RequestHandler(RequestCriteria request_criteria, ISupportAStory application_feature)
    {
      this.request_criteria = request_criteria;
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