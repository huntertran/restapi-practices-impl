using Microsoft.EntityFrameworkCore;
using sampleApi.Utils.PaginationForList;
using sampleApi.Utils.PostPutPatchReturn.Models;

namespace sampleApi.Utils
{
    public class MyDbContext : DbContext
    {
        public MyDbContext(DbContextOptions<MyDbContext> options) : base(options)
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            //  #warning To protect potentially sensitive information in your connection string, 
            //  you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 
            //  for guidance on storing connection strings.

            optionsBuilder.UseMySQL("server=20.151.2.26;port=3306;database=db_example;user=springuser;password=ThePassword");
        }

        public DbSet<Student> Students { get; set; }
        public DbSet<Transaction> transaction { get; set; }
    }
}