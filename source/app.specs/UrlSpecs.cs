using Machine.Specifications;
using app.specs.utility;
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

    public class when_getting_the_url_gateway : concern
    {
      Establish context = () =>
      {
        using (var scaffold = ObjectFactory.container.scaffold(spec, fake))
        {
          url_builder = scaffold.an<IUrlBuilder>();
        }
      };

      Because of = () => 
        result = Url.to;

      It should_return_the_correct_url_builder = () => 
        result.ShouldEqual(url_builder);

      static IUrlBuilder url_builder;
      static IUrlBuilder result;
    }
  }
}