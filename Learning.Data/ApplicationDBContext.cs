using Learning.Data.UserEntity;
using Microsoft.EntityFrameworkCore;

namespace Learning.Data
{
    public class ApplicationDBContext : DbContext
    {
        public ApplicationDBContext(DbContextOptions<ApplicationDBContext> options) :
        base(options) { }

        public DbSet<User> Users { get; set; }
    }
}
