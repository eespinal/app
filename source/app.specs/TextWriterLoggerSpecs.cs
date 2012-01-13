using System;
using System.Data;
using System.IO;
using System.Text;
using Machine.Specifications;
using app.utility.logger;
using app.utility.logger.basic;
using app.utility.logger.core;
using developwithpassion.specifications.rhinomocks;

namespace app.specs
{
  [Subject(typeof(TextWriterLogger))]
  public class TextWriterLoggerSpecs
  {
    public abstract class concern : Observes<ILog, TextWriterLogger>
    {
    }

    public class when_logging_the_information : concern
    {
      Establish context = () =>
      {
        the_type = typeof(IDbConnection);
        message = "random message";
        builder = new StringBuilder();
        depends.on(the_type);
        depends.on<TextWriter>(new StringWriter(builder));
        depends.on<LogMessageFormatter>((x,item) =>
        {
          x.ShouldEqual(the_type);
          item.ShouldEqual(message);
          return message;
        });
      };

      Because of = () =>
        sut.informational(message);

      It should_write_the_message_to_its_writer = () =>
        builder.ToString().ShouldEqual(message);

      static string message;
      static StringBuilder builder;
      static Type the_type;
    }
  }
}