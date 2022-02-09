using Entities;
using Microsoft.EntityFrameworkCore;

//Endre til API.Data?
//ctrl + . for å generere konstruktører og lignende
namespace API.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<AppUser> Users { get; set; }
    }
}