using Machine.Specifications;
using app.web.application.catalogbrowing;
using app.web.core;
using app.web.core.rendering;
using app.web.core.urls;
using developwithpassion.specifications.extensions;
using developwithpassion.specifications.rhinomocks;

namespace app.specs
{
  [Subject(typeof(UrlBuilder))]
  public class UrlBuilderSpecs
  {
    public abstract class concern : Observes<IUrlBuilder,
                                      UrlBuilder>
    {
    }

    public class when_asked_to_build : concern
    {
      //Url.to.build<Report>()
      Establish c = () =>
      {
        report_type_path = "/StubReportType";
      };

      Because b = () =>
        result = sut.build<StubReportType>();

      It should_return_the_path_to_the_report_type = () =>
        result.ShouldEqual(report_type_path);

      static string result;
      private static string report_type_path;
    }
  }

  public class StubReportType
  {
  }
}