namespace app.web.core
{
  public interface IProcessASingleRequest : ISupportAStory
  {
    bool can_process(IProvideDetailsToCommands the_request);
  }
}