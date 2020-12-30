using Krunker.Common.Enums;
using Krunker.Common.Interfaces;
using Krunker.Common.Models;
using System;

namespace Krunker.Common.DTOs
{
    public class ShoppingItemDTO
    {
        public string Name { get; init; }
        public string UriImg { get; init; }
        public int Discount { get; init; }
        public double Price { get; init; }
        public Guid Id { get; init; }

        public int CurrentAmount { get; init; }
        public ItemKind Kind { get; set; }

        public ShoppingItemDTO(IShoppingItem item)
        {
            Name = item.Name;
            UriImg = item.UriImg;
            Discount = item.Discount;
            Price = item.Price;
            Id = item.Id;
            CurrentAmount = item.CurrentAmount;
            Kind = item.Kind;
        }

        public static ShoppingItemDTO FromDbModel(IShoppingItem item)
        {
            return item switch
            {
                BackItem i => new BackItemDTO(i),
                PrimaryWeapon i => new PrimaryWeaponDTO(i),
                SecondaryWeapon i => new SecondaryWeaponDTO(i),
                _ => new ShoppingItemDTO(item),
            };
        }
    }
}
