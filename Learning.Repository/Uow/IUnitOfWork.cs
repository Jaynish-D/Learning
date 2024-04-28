using Learning.Repository.UserRepo;

namespace Learning.Repository.Uow
{
    public interface IUnitOfWork : IDisposable
    {
        Task CommitAsync();

        IUserRepository Users { get; }
    }
}
