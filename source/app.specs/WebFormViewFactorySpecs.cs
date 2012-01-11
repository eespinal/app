using Machine.Specifications;
using app.web.core.aspnet;
using developwithpassion.specifications.extensions;
using developwithpassion.specifications.rhinomocks;

namespace app.specs
{
  [Subject(typeof(WebFormViewFactory))]
  public class WebFormViewFactorySpecs
  {
    public abstract class concern : Observes<ICreateViews,
                                      WebFormViewFactory>
    {
    }

    public class when_creating_a_view_to_display_a_report : concern
    {
      Establish c = () =>
      {
        template_path_registry = depends.on<IFindPathsToTemplates>();
        report = new AReport();
      };

      Because b = () =>
        sut.create_view_that_can_render(report);


      It should_get_the_path_to_the_template_that_can_display_the_report = () =>
        template_path_registry.received(x => x.get_path_to_template_for<AReport>());

      static IFindPathsToTemplates template_path_registry;
      static AReport report;
    }

    public class AReport
    {
    }
  }
}