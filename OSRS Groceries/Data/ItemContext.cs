using Microsoft.EntityFrameworkCore;
using OSRS_Groceries.Models;

namespace OSRS_Groceries.Data
{
    public class ItemContext : DbContext
    {
        public ItemContext(DbContextOptions<ItemContext> options) : base(options)
        {

        }

        public virtual DbSet<Item> Item { get; set; }
    }
}
