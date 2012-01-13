using System;
using System.IO;
using app.utility.logger.core;

namespace app.utility.logger.basic
{
  public class TextWriterLogger : ILog
  {
    public TextWriter writer;
    public Type type_its_logging_for;
    public LogMessageFormatter format;

    public TextWriterLogger(TextWriter writer, Type type_its_logging_for,LogMessageFormatter format)
    {
      this.writer = writer;
      this.type_its_logging_for = type_its_logging_for;
      this.format = format;
    }

    public void informational(string message)
    {
      writer.Write(format(type_its_logging_for, message));
    }
  }
}