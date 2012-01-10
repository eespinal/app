namespace app.web.core
{
  public interface IProcessASingleRequest
  {
    void process(IProvideDetailsToCommands the_request);
    bool can_process(IProvideDetailsToCommands the_request);
  }
}