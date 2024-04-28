using Learning.Data.UserEntity;
using Learning.Models.UserModels;
using Learning.Repository.GenericRepo;

namespace Learning.Repository.UserRepo
{
    public interface IUserRepository : IGenericRepository<User>
    {
        Task<UserCreateModel> CreateUser(UserCreateModel model);
    }
}
