using Krunker.Common.Models;
using Krunker.DAL.Helpers;
using Microsoft.EntityFrameworkCore;

namespace Krunker.DAL
{
    /// <summary>
    /// The DbContext handeling the shop related tables.
    /// </summary>
    public class ShopContext : DbContext
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ShopContext"/> class using the specified options.
        /// </summary>
        /// <param name="options">The options for this context.</param>
        public ShopContext(DbContextOptions<ShopContext> options) : base(options) { }
        /// <summary>
        /// The set of all Back Items.
        /// </summary>
        public DbSet<BackItem> BackItems { get; set; }
        /// <summary>
        /// The set of all Head Items.
        /// </summary>
        public DbSet<HeadItem> HeadItems { get; set; }
        /// <summary>
        /// The set of all Primary Weapons.
        /// </summary>
        public DbSet<PrimaryWeapon> PrimaryWeapons { get; set; }
        /// <summary>
        /// The set of all Secondary Weapons.
        /// </summary>
        public DbSet<SecondaryWeapon> SecondaryWeapons { get; set; }
        /// <summary>
        /// The set of all Shopping Carts.
        /// </summary>
        public DbSet<ShoppingCart> ShoppingCarts { get; set; }
        /// <summary>
        /// The set of all Purchases.
        /// </summary>
        public DbSet<Purchase> Purchases { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.InjectPrePopulatedData();
        }
    }
}
