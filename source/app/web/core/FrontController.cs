namespace app.web.core
{
    public class FrontController : IProcessRequests
    {
        readonly IFindCommands command_registry;

        public FrontController(IFindCommands commandRegistry)
        {
            command_registry = commandRegistry;
        }

        public void process(IProvideDetailsToCommands new_request)
        {
            var command = command_registry.get_the_command_that_can_process(new_request);
            command.process(new_request);
        }
    }
}