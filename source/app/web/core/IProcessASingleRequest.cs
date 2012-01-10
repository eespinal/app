namespace app.web.core
{
  public interface IProcessASingleRequest
  {
    void process(IProvideDetailsToCommands the_request);
  }
}