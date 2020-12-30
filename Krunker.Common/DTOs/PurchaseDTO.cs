using Krunker.Common.Models;
using System;

namespace Krunker.Common.DTOs
{
    public class PurchaseDTO
    {
        public Guid Id { get; init; }
        public ShoppingItemDTO Item { get; init; }

        public int Amount { get; init; }
        public double DiscountRate { get; init; }
        public double PriceAtPurchase { get; init; }

        public static PurchaseDTO FromDbModel(Purchase purchase)
        {
            return new()
            {
                Id = purchase.Id,
                Item = ShoppingItemDTO.FromDbModel(purchase.Item),
                Amount = purchase.Amount,
                DiscountRate = purchase.DiscountRate,
                PriceAtPurchase = purchase.PriceAtPurchase
            };
        }
    }
}