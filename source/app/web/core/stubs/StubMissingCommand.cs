namespace app.web.core.stubs
{
  public class StubMissingCommand:IProcessASingleRequest
  {
    public void process(IProvideDetailsToCommands the_request)
    {
    }

    public bool can_process(IProvideDetailsToCommands the_request)
    {
      return false;
    }
  }
}