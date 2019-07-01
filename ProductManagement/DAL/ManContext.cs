using Entity;
using Microsoft.EntityFrameworkCore;
using System;

namespace DAL
{
    public class ManContext : DbContext
    {
        public ManContext(DbContextOptions options) : base(options)
        {

        }
        public virtual DbSet<User> Users { get; set; }
        public virtual DbSet<Product> Products { get; set; }

        protected override void OnModelCreating(ModelBuilder mb)
        {
            //Primary Key Column
            mb.Entity<User>()
                .HasKey(x => x.Id);
            mb.Entity<Product>()
                .HasKey(x => x.Id);

            //Index Column
            mb.Entity<User>()
                .HasIndex(x => x.Email);
            

            //FK
            mb.Entity<Product>()
                .HasOne(x => x.User)
                .WithMany(x => x.Products)
                .HasForeignKey(x => x.UserId);

            base.OnModelCreating(mb);
        }
    }
}
