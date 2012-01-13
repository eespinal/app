using System.Data;

namespace app.utility.logger
{
    public class Logger : ILogInformation
    {
        MessageWritter message_writter;

        public Logger(MessageWritter message_writter)
        {
            this.message_writter = message_writter;
        }

        public void information(string message)
        {
            message_writter(string.Format("info: {0}", message));
        }
    }
}