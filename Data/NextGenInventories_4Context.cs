using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using NextGenInventories_4.Models;

namespace NextGenInventories_4.Data
{
    public class NextGenInventories_4Context : DbContext
    {
        public NextGenInventories_4Context (DbContextOptions<NextGenInventories_4Context> options)
            : base(options)
        {
        }

        public DbSet<NextGenInventories_4.Models.Inventory> Inventory { get; set; } = default!;

        public DbSet<NextGenInventories_4.Models.Product> Product { get; set; } = default!;

        public DbSet<NextGenInventories_4.Models.User> User { get; set; } = default!;

        public DbSet<NextGenInventories_4.Models.Ingredient> Ingredient { get; set; } = default!;

        public DbSet<NextGenInventories_4.Models.Recipe> Recipe { get; set; } = default!;

        public DbSet<NextGenInventories_4.Models.InventoryDate> InventoryDate { get; set; } = default!;
    }
}
