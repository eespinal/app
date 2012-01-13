using System;
using System.Collections.Generic;
using System.Linq;
using Machine.Specifications;
using app.utility.containers.core;
using app.web.core;
using app.web.core.requestmatching;
using developwithpassion.specifications.rhinomocks;
using developwithpassion.specifications.extensions;

namespace app.specs
{
  [Subject(typeof(RouteTable))]
  public class RouteTableSpecs
  {
    public abstract class concern : Observes<IRegisterRoutes, RouteTable>
    {
    }

    public class when_iterating : concern
    {
      Establish context = () =>
      {
        first = fake.an<IProcessASingleRequest>();
        items = new List<IProcessASingleRequest> {first};
        depends.on(items);
      };

      Because of = () =>
        resuls = sut;

      It should_return_all_of_the_registered_processors = () =>
        resuls.ShouldContainOnly(first);

      static IList<IProcessASingleRequest> items;
      static IEnumerable<IProcessASingleRequest> resuls;
      static IProcessASingleRequest first;
    }
    public class when_registering_a_report : concern
    {
      Establish context = () =>
      {
        request_criteria = x => true;
        items = new List<IProcessASingleRequest>();
        reports = fake.an<IDisplayReports>();
        the_query = fake.an<StubQuery>();
        matchers = depends.on<IBuildRequestMatchers>();
        the_container = depends.on<IFetchDependencies>();
        matchers.setup(x => x.made_for<StubViewRequestModel>()).Return(request_criteria);
        the_container.setup(x => x.an<StubQuery>()).Return(the_query);
        the_container.setup(x => x.an<IDisplayReports>()).Return(reports);


        depends.on(items);
      };

      Because of = () => sut.a_report<StubViewRequestModel, StubQuery, StubReportModel>();

      It should_create_a_process_a_single_request_with_the_correct_information = () =>
      {
        var handler = items.First().ShouldBeAn<RequestHandler>();
        handler.request_criteria.ShouldEqual(request_criteria);

        var feature = handler.application_feature.ShouldBeAn<ViewA<StubReportModel>>();
        feature.report_query.ShouldEqual(the_query);
        feature.display_engine.ShouldEqual(reports);
      };

      static RequestCriteria request_criteria;
      static IProcessASingleRequest missing_command;
      static IBuildRequestMatchers matchers;
      static IList<IProcessASingleRequest> items;
      static IFetchDependencies the_container;
      static StubQuery the_query;
      static IDisplayReports reports;
    }
  }

  public class StubReportModel
  {
  }

  public class StubQuery : IFetchA<StubReportModel>
  {
    public StubReportModel fetch_using(IProvideDetailsToCommands request)
    {
      throw new NotImplementedException();
    }
  }

  public class StubViewRequestModel
  {
  }
}