using System;
using System.Collections.Generic;
using System.Linq;
using Finance.Interfaces;

namespace Finance.Commands
{
    public class GetCommandByIdQuery
    {
        private readonly IEnumerable<Command> commands;

        public GetCommandByIdQuery(IEnumerable<Command> commands)
        {
            this.commands= commands;
        }

        public void Execute(int id)
        {
            commands.FirstOrDefault(e => e.Id == id).TypeCommand.Execute();
        }
    }
}
