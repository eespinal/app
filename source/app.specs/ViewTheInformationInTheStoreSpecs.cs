using System.Collections.Generic;
using Machine.Specifications;
using app.web.application.catalogbrowing;
using app.web.core;
using developwithpassion.specifications.extensions;
using developwithpassion.specifications.rhinomocks;

namespace app.specs
{
  [Subject(typeof(ViewTheInformationInTheStore<StubModel>))]
  public class ViewTheInformationInTheStoreSpecs
  {
    public abstract class concern : Observes<ISupportAStory,
                                      ViewTheInformationInTheStore<StubModel>>
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
        report_engine = depends.on<IGetReports<StubModel>>();
        report_engine.setup(x=>x.get_report(the_request)).Return(report);
      };

      Because b = () =>
        sut.process(the_request);


      It should_display_the_main_departments = () =>
        display_engine.received(x => x.display(report));

      static IProvideDetailsToCommands the_request;
      static IDisplayReports display_engine;
      private static StubModel report;
      private static IGetReports<StubModel> report_engine;
    }
  }
}