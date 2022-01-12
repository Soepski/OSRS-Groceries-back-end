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

        //protected override void OnModelCreating(ModelBuilder modelBuilder)
        //{         
        //    modelBuilder.Entity<Item_User>()
        //        .HasOne(i => i.User)
        //        .WithMany(iu => iu.Item_User)
        //        .HasForeignKey(ii => ii.UserID);

        //    modelBuilder.Entity<Item_User>()
        //        .HasOne(i => i.Item)
        //        .WithMany(iu => iu.Item_User)
        //        .HasForeignKey(ii => ii.ItemID);
        //}

        public DbSet<Item> Items { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Item_User> Item_User { get; set; }
    }
}
