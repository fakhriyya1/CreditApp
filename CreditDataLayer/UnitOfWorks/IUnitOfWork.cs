using CreditDataLayer.Repositories.Abstractions;

namespace CreditDataLayer.UnitOfWorks
{
	public interface IUnitOfWork : IAsyncDisposable
    {
        IRepository<T> GetRepository<T>() where T : class, new();

        Task<int> SaveAsync();
        int Save();
    }
}
