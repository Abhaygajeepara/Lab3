using Lab3.Model;
using Microsoft.EntityFrameworkCore;

namespace Lab3.DatabaseContext
{
    public class MyDatabaseContext:DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            // base.OnConfiguring(optionsBuilder);
            optionsBuilder.UseInMemoryDatabase(databaseName:"UserDB");
        }

        public DbSet<UserModel> users { get; set; }


        
    }
}
