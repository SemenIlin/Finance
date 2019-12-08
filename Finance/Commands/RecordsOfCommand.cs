using System.Collections.Generic;
using System.Linq;
using Finance.Interfaces;
using Finance.Interfaces.Operations;

namespace Finance.Commands
{
    public class RecordsOfCommand : IEnumerable<Command>
    {        
        private readonly ICollection<Command> commands;

        public RecordsOfCommand(ICollection<Command> commands)
        {
          this.commands = commands;
        }

        public void AddCommand(string text, ICommand command)
        {
            int maxId;
            if (commands.Count == 0)
            {
                maxId = 1;
            }
            else
            {
                maxId = commands.Max(e => e.Id) + 1; 
            }
            commands.Add(new Command()
            {
                Id = maxId,
                Text = text,
                TypeCommand = command
            });
        }

        public IEnumerator<Command> GetEnumerator() 
        {
            return commands.GetEnumerator();        
        }

        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
        {
            return commands.GetEnumerator();
        }

    }
}
