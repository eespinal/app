using app.utility.containers.core;

namespace app.web.core.urls
{
  public class Url
  {
    public static IUrlBuilder to
    {
      get
      {
        {
          return Container.fetch.an<IUrlBuilder>();
        }
      }
    }
  }