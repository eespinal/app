 using System;
 using System.IO;
 using Machine.Specifications;
 using app.utility.logger;
 using app.utility.logger.basic;
 using app.utility.logger.core;
 using developwithpassion.specifications.rhinomocks;
 using developwithpassion.specifications.extensions;

namespace app.specs
{  
  [Subject(typeof(TextWriterLoggerFactory))]  
  public class TextWriterLoggerFactorySpecs
  {
    public abstract class concern : Observes<ICreateLoggers,
                                      TextWriterLoggerFactory>
    {
        
    }

   
    public class when_creating_a_logger : concern
    {
      Establish c = () =>
      {
        writer = fake.an<TextWriter>();
        the_type = typeof(int);
        format = depends.on<LogMessageFormatter>();
        depends.on<LogWriterFactory>(() => writer);
      };

      Because b = () =>
        result = sut.create_logger_bound_to(the_type);


      It should_create_the_logger_with_the_correct_information = () =>
      {
        var item = result.ShouldBeAn<TextWriterLogger>();
        item.format.ShouldEqual(format);
        item.writer.ShouldEqual(writer);
        item.type_its_logging_for.ShouldEqual(the_type);
      };

      static ILog result;
      static LogMessageFormatter format;
      static TextWriter writer;
      static Type the_type;
      static LogWriterFactory log_writer_factory;
    }
  }
}
