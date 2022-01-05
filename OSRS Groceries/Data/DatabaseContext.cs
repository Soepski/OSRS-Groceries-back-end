using Microsoft.EntityFrameworkCore;
using OSRS_Groceries.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OSRS_Groceries.Data
{
    public class DatabaseContext : DbContext
    {
        public DatabaseContext(DbContextOptions<DatabaseContext> options) : base (options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Item_User>()
                .HasOne(i => i.Item)
                .WithMany(iu => iu.Item_Users)
                .HasForeignKey(ii => ii.ItemID);

            modelBuilder.Entity<Item_User>()
                .HasOne(i => i.User)
                .WithMany(iu => iu.Item_Users)
                .HasForeignKey(ii => ii.UserID);

        }

        public DbSet<Item> Items { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Item_User> Items_Users { get; set; }
    }
}
