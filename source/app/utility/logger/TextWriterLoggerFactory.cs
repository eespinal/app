using System;

namespace app.utility.logger
{
  public class TextWriterLoggerFactory : ICreateLoggers
  {
    LogWriterFactory log_writer_factory;
    LogMessageFormatter formatter;

    public TextWriterLoggerFactory(LogWriterFactory log_writer_factory, LogMessageFormatter formatter)
    {
      this.log_writer_factory = log_writer_factory;
      this.formatter = formatter;
    }

    public ILog create_logger_bound_to(Type type)
    {
      return new TextWriterLogger(log_writer_factory(), type, formatter);
    }
  }
}