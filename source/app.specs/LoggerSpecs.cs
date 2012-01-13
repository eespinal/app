using System;
using Machine.Specifications;
using app.utility.logger;
using developwithpassion.specifications.rhinomocks;
using developwithpassion.specifications.extensions;

namespace app.specs
{
    [Subject(typeof (Logger))]
    public class LoggerSpecs
    {
        public abstract class concern : Observes<ILogInformation, Logger>
        {
        }

        public class when_logging_the_information : concern
        {

            Establish context = () =>
                                    {
                                        message_writter =depends.on<MessageWritter>(); 
                                        depends.on<MessageWritter>();
                                        message = "random message";
                                    };

            Because of = () => sut.information(message);

            It should_log_the_messga = () => message_writter.received(x => x(string.Format("info: {0}", message)));
            static string message;
            static MessageWritter message_writter;
        }
    }
}