using Krunker.Common.Interfaces;
using System;

namespace Krunker.Common.Models
{
    public class Purchase : IHasID
    {
        public Guid Id { get; set; }

        public virtual Guid ItemId { get; set; }
        public virtual ShoppingItem Item { get; set; }
        public virtual Guid ShoppingCartId { get; set; }
        public virtual ShoppingCart ShoppingCart { get; set; }

        public int Amount { get; set; }
        public double DiscountRate { get; set; }
        public double PriceAtPurchase { get; set; }
    }
}
