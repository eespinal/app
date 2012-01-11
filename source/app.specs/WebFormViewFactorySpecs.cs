using System.Web;
using System.Web.UI;
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
        the_view = fake.an<IDisplayA<AReport>>();
        path_from_registry = "blah.aspx";
        template_path_registry.setup(x => x.get_path_to_template_for<AReport>()).Return(path_from_registry);
        depends.on<WebFormFactory>((path,type) =>
        {
          path.ShouldEqual(path_from_registry);
          type.ShouldEqual(typeof(IDisplayA<AReport>));
          return the_view;
        });
      };

      Because b = () =>
        result = sut.create_view_that_can_render(report);


      It should_populate_the_data_for_the_template_instance = () =>
        the_view.report.ShouldEqual(report);
        
      It should_return_the_template_instance_created_by_the_template_factory = () =>
        result.ShouldEqual(the_view);

        

      static IFindPathsToTemplates template_path_registry;
      static AReport report;
      static IHttpHandler result;
      static IDisplayA<AReport> the_view;
      static string path_from_registry;
    }

    public class AReport
    {
    }
  }
}