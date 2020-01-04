
namespace Finance.DAL.Interfaces
{
    public interface IUnitOfWork<T> where T:class
    {
        IRepository<T> Repository { get; }
    }
}
