using Machine.Specifications;
using app.web.core;
using developwithpassion.specifications.rhinomocks;
using System.Linq;

namespace app.specs
{
    [Subject(typeof(RegisterRoutes))]  
    public class RegisterRoutesSpecs
    {

        public abstract class concern : Observes<IRegisterRoutes, RegisterRoutes>
        {
        
        }
        public class when_registering_a_report : concern
        {
            Establish context = () =>
                                    {
                                        request_criteria = depends.on<RequestCriteria>();
                                        missing_command = depends.on<IProcessASingleRequest>();
                                    };
            Because of = () => sut.a_report<StubViewRequestModel,StubQuery,StubReportModel>();

            It should_create_a_process_a_single_request_for_the_report_model= () =>
                                         {
                                             var process_a_single_request = sut.First() as RequestHandler;
                                             process_a_single_request.request_criteria.ShouldBeTheSameAs(request_criteria);
                                             process_a_single_request.application_feature.ShouldBeTheSameAs(missing_command);
                                         };

            static RequestCriteria request_criteria;
            static IProcessASingleRequest missing_command;
        }
    }

    public class StubReportModel
    {
    }

    public class StubQuery : IFetchA<StubReportModel>
    {
        public StubReportModel fetch_using(IProvideDetailsToCommands request)
        {
            throw new System.NotImplementedException();
        }
    }

    public class StubViewRequestModel
    {
    }
}