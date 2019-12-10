namespace Finance.Commands
{
    public interface ICommandHandler<TRequest> where TRequest : ICommand
    {
        void Handle(TRequest query);        
    }
}
