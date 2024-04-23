using Microsoft.EntityFrameworkCore;
using TraversalApiProject.Dal.Entities;

namespace TraversalApiProject.Dal.Context
{
    public class VisitorContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("server=OGUZHAN;initial catalog=TraversalDbApi;integrated Security=true");
        }

        public DbSet<Visitor> visitors { get; set; }
    }
}