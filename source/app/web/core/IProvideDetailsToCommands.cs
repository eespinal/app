namespace app.web.core
{
  public interface IProvideDetailsToCommands
  {
    InputModel map<InputModel>();
    string request_name { get; }
  }
}