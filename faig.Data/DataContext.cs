using faig.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace faig.Data
{
    public class DataContext: DbContext
    {
      
        public DbSet<User> Users { get; set; }
        public DbSet<Presence> Presence { get; set; }
        public readonly IConfiguration _configuration;

        public DataContext( IConfiguration configuration)
        {
            _configuration = configuration;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=(localdb)\\ProjectModels;Database=new_presence_db;Trusted_Connection=True;");
            //optionsBuilder.UseSqlServer(@"Server=(localdb)\MSSQLLocalDB;Database=my_db;");
        }
        //"DbConnectionString": "Server=(localdb)\\ProjectModels;Database=new_presence_db;Trusted_Connection=True;"

    }
}