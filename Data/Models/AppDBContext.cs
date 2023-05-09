using Microsoft.EntityFrameworkCore;

namespace SimpleProject.Data.Models
{
    public class AppDBContext: DbContext
    {
        public AppDBContext(DbContextOptions<AppDBContext> options): base(options)
        {
            
        }
        public DbSet <Book> Books { get; set; }
    }
}
