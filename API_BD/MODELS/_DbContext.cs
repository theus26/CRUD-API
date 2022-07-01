using Microsoft.EntityFrameworkCore;

namespace API_BD.MODELS
{
    public class _DbContext:DbContext
    {
        public _DbContext(DbContextOptions<_DbContext> options) : base(options)
        { }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
        }

        public DbSet<Clientes>clliente { get; set; }
    }
}
