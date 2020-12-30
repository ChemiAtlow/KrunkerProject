using Krunker.Common.Models;
using Krunker.DAL.DummyData;
using Microsoft.EntityFrameworkCore;

namespace Krunker.DAL.Helpers
{
    public static class ModelBuilderExtensions
    {
        /// <summary>
        /// Seed the DB.
        /// </summary>
        /// <param name="modelBuilder">The builder being used to construct the model for this context.</param>
        /// <returns>The model builder.</returns>
        public static ModelBuilder InjectPrePopulatedData(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<BackItem>().HasData(PrePopulateData.backItems);
            modelBuilder.Entity<HeadItem>().HasData(PrePopulateData.headItems);
            modelBuilder.Entity<PrimaryWeapon>().HasData(PrePopulateData.primaryWeapons);
            modelBuilder.Entity<SecondaryWeapon>().HasData(PrePopulateData.secondaryWeapons);
            modelBuilder.Entity<ShoppingCart>().HasData(PrePopulateData.shoppingCarts);
            modelBuilder.Entity<Purchase>().HasData(PrePopulateData.purchases);
            return modelBuilder;
        }
    }
}
