using System.Collections.Generic;
using System.Linq;

namespace app.web.core
{
  public class CommandRegistry : IFindCommands
  {
    IEnumerable<IProcessASingleRequest> all_commands;

    public CommandRegistry(IEnumerable<IProcessASingleRequest> all_commands)
    {
      this.all_commands = all_commands;
    }

    public IProcessASingleRequest get_the_command_that_can_process(IProvideDetailsToCommands the_request)
    {
      return all_commands.First(x => x.can_process(the_request));
    }
  }
}