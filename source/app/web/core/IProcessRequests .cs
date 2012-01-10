namespace app.web.core
{
  public interface IProcessRequests 
  {
    void process(IProvideDetailsToCommands new_request);
  }
}