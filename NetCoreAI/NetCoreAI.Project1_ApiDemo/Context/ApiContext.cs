using Microsoft.EntityFrameworkCore;
using NetCoreAI.Project1_ApiDemo.Entities;
namespace NetCoreAI.Project1_ApiDemo.Context
{
    public class ApiContext : DbContext

    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=LAPTOP-9R5N0H2G;initial catalog=ApiAIDb;integrated security=true;trustservercertificate=true");
        }
        public DbSet<Customer> Customers { get; set; }
    }
}
