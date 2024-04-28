using Learning.Data;
using Learning.Repository.UserRepo;

namespace Learning.Repository.Uow
{
    public class UnitOfWork(ApplicationDBContext context) : IUnitOfWork
    {
        public async Task CommitAsync()
        {
            await context.SaveChangesAsync();
        }

        public IUserRepository Users
        {
            get
            {
                var user = new UserRepository(context);
                return user;
            }
        }

        public void Dispose()
        {
            context.Dispose();
        }
    }
}
