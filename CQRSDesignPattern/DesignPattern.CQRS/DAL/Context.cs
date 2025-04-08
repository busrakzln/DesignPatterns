using Microsoft.EntityFrameworkCore;

namespace DesignPattern.CQRS.DAL
{
    public class Context:DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("server=.\\SQLEXPRESS; initial catalog=DesignPatter2; integrated security=true;");
        }

        public DbSet<Product> Products { get; set; }

        public static implicit operator Context(ContextBoundObject v)
        {
            throw new NotImplementedException();
        }
    }
}
