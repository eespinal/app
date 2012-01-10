namespace app.web.core
{
    public class FrontController : IProcessRequests
    {
        readonly IFindCommands command_finder;

        public FrontController(IFindCommands commandFinder)
        {
            command_finder = commandFinder;
        }

        public void process(IProvideDetailsToCommands new_request)
        {
            var command = command_finder.get_the_command_that_can_process(new_request);
            command.process(new_request);
        }
    }
}