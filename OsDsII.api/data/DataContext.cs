using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using OsDsII.api.Models;

namespace OsDsII.api.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        { }
        public DbSet<ServiceOrder> ServiceOrders { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Comment> Comments { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            modelBuilder.Entity<Customer>().ToTable("Customer");
            modelBuilder.Entity<Customer>().HasKey();
            modelBuilder.Entity<Customer>().HasIndex(c => c.Email).IsUnique();
            modelBuilder.Entity<Customer>().Property(c => c.Id).ValueGeneratedOnAdd();
            modelBuilder.Entity<Customer>().Property(c => c.Name).HasMaxLength(60);
            modelBuilder.Entity<Customer>().Property(c => c.Email).HasMaxLength(255);
            modelBuilder.Entity<Customer>().Property(c => c.Phone).HasMaxLength(20);

            modelBuilder.Entity<ServiceOrder>().ToTable("service_order");
            modelBuilder.Entity<ServiceOrder>().HasKey(s => s.Id);
            modelBuilder.Entity<ServiceOrder>().Property(s => s.Id).ValueGeneratedOnAdd();
            modelBuilder.Entity<ServiceOrder>().Property(s => s.Description).HasMaxLength(255);



        }
    }
}