using Microsoft.EntityFrameworkCore;
using sampleApi.Utils.PostPutPatchReturn;

namespace sampleApi.Utils
{
    public class MyDbContext : DbContext
    {
        public MyDbContext(DbContextOptions<MyDbContext> options) : base(options)
        {
        }

        public DbSet<Student> Students { get; set; }
    }
}