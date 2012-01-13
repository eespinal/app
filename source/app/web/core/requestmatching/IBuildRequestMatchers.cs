namespace app.web.core.requestmatching
{
  public interface IBuildRequestMatchers
  {
    RequestCriteria made_for<RequestType>();
  }
}