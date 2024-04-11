using Microsoft.EntityFrameworkCore;
using Model = Todo.Interface.DataModels;

namespace Todo.Implementation.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<Model.Todo> Todos { get; set; }
    }
}
