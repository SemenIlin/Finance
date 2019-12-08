namespace Finance.Interfaces.Operations
{
    public interface IQueryHandler<TRequest, TResponse> 
        where TRequest : IQuery<TResponse>
    {
        TResponse Handle(TRequest query);
    }
}
