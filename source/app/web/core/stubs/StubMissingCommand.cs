namespace app.web.core.stubs
{
  public class StubMissingCommand:IProcessASingleRequest
  {
    public bool can_process(IProvideDetailsToCommands the_request)
    {
      return false;
    }

    public void process(IProvideDetailsToCommands the_request)
    {
    }
  }
}