using Finance.Interfaces;
using Finance.Interfaces.Operations;

namespace Finance.Commands
{
    public class Command
    {
        public int Id { get; set; }
        public string Text { get; set; }
        public ICommand TypeCommand { get; set; }
    }
}
