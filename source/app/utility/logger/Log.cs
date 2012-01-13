using app.utility.containers.core;

namespace app.utility.logger
{
    public class Log
    {
        public static ILogInformation an { get { return Container.fetch.an<ILogInformation>(); } }
    }
}