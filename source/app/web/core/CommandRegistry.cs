﻿using System.Collections.Generic;
using System.Linq;
using app.utility;
using app.web.core.stubs;

namespace app.web.core
{
  public class CommandRegistry : IFindCommands
  {
    IEnumerable<IProcessASingleRequest> all_commands;
    IProcessASingleRequest missing_command;

    public CommandRegistry(IProcessASingleRequest missingCommand, IEnumerable<IProcessASingleRequest> allCommands)
    {
      missing_command = missingCommand;
      all_commands = allCommands;
    }

    public CommandRegistry():this(Stub.with<StubMissingCommand>(),Stub.with<StubFakeSetOfCommands>())
    {
    }

    public IProcessASingleRequest get_the_command_that_can_process(IProvideDetailsToCommands the_request)
    {
      return all_commands.FirstOrDefault(x => x.can_process(the_request)) ?? missing_command;
    }
  }
}