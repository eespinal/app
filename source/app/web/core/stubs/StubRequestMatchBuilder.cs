using app.web.core.requestmatching;

namespace app.web.core.stubs
{
  public class StubRequestMatchBuilder:IBuildRequestMatchers
  {
    public RequestCriteria made_for<RequestType>()
    {
      return x => true;
    }
  }
}