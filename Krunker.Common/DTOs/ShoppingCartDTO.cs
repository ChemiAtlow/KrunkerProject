using Krunker.Common.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Krunker.Common.DTOs
{
    public class ShoppingCartDTO
    {
        public Guid Id { get; set; }
        public double TotalPrice { get; set; }
        public bool PurchaseComplete { get; set; }
        public DateTime PurchaseTime { get; set; }
        public IEnumerable<PurchaseDTO> Purchases { get; set; }

        public static ShoppingCartDTO FromDbModel(ShoppingCart item)
        {
            return new()
            {
                Id = item.Id,
                TotalPrice = item.TotalPrice,
                PurchaseComplete = item.PurchaseComplete,
                PurchaseTime = item.PurchaseTime,
                Purchases = (item.Purchases ?? Enumerable.Empty<Purchase>()).Select(p => PurchaseDTO.FromDbModel(p))
            };
        }
    }
}
