using Machine.Specifications;
using app.specs.utility;
using app.utility.logger;
using developwithpassion.specifications.rhinomocks;

namespace app.specs
{
    [Subject(typeof (Log))]
    public class LogSpecs
    {
        public abstract class concern : Observes
        {
        }

        public class when_getting_the_log_gateway : concern
        {
            Establish context = () => logger = ObjectFactory.container.scaffold(spec, fake).an<ILogInformation>();

            Because of = () => result= Log.an;

            It should_return_the_logger = () => result.ShouldEqual(logger);
            static ILogInformation logger;
            static ILogInformation result;
        }
    }
}