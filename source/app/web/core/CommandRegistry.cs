using System.Collections.Generic;
using System.Linq;

namespace app.web.core
{
  public class CommandRegistry:IFindCommands
  {
      readonly IEnumerable<IProcessASingleRequest> allTheCommands;

      public CommandRegistry(IEnumerable<IProcessASingleRequest> all_the_commands )
      {
          allTheCommands = all_the_commands;
      }

      public IProcessASingleRequest get_the_command_that_can_process(IProvideDetailsToCommands the_request)
      {
          return allTheCommands.First(x => x.can_process(the_request));
      }
  }
}