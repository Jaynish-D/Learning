using AutoMapper;
using Learning.Data;
using Learning.Data.UserEntity;
using Learning.Models.UserModels;
using Learning.Repository.GenericRepo;

namespace Learning.Repository.UserRepo
{
    public class UserRepository : GenericRepository<User>, IUserRepository
    {
        private readonly IMapper _mapper;
        public UserRepository(ApplicationDBContext context, IMapper mapper) : base(context)
        {
            _mapper = mapper;
        }

        public async Task<UserCreateModel> CreateUser(UserCreateModel model)
        {
            var user = _mapper.Map<User>(model);

            return model;
        }
    }
}
