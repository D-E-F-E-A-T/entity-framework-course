using System.Data.Entity;

namespace CodeFirstDemo
{
    public class CodeFirstDemoContext : DbContext
    {
        public DbSet<Event> Events { get; set; }
    }
}
