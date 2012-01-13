using Machine.Specifications;
using app.web.core.urls;
using developwithpassion.specifications.rhinomocks;

namespace app.specs
{
  [Subject(typeof(Url))]
  public class UrlSpecs
  {
    public abstract class concern : Observes
    {
    }

    public class when_observation_name : concern
    {
      It first_observation = () => 
    }
  }
}