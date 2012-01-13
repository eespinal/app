using Machine.Specifications;
using app.web.application.catalogbrowing;
using app.web.core;
using app.web.core.rendering;
using developwithpassion.specifications.extensions;
using developwithpassion.specifications.rhinomocks;

namespace app.specs
{
  [Subject(typeof(ViewAReportModel<StubModel>))]
  public class ViewASpecs
  {
    public abstract class concern : Observes<ISupportAStory,
                                      ViewAReportModel<StubModel>>
    {
    }

    public class StubModel
    {
    }

    public class when_run : concern
    {
      Establish c = () =>
      {
        display_engine = depends.on<IDisplayReports>();
        the_request = fake.an<IProvideDetailsToCommands>();
        report = new StubModel();
        report_engine = depends.on<IQueryForAReportModel<StubModel>>();
        report_engine.setup(x => x.fetch_using(the_request)).Return(report);
      };

      Because b = () =>
        sut.process(the_request);

      It should_display_the_main_departments = () =>
        display_engine.received(x => x.display(report));

      static IProvideDetailsToCommands the_request;
      static IDisplayReports display_engine;
      static StubModel report;
      static IQueryForAReportModel<StubModel> report_engine;
    }
  }
}