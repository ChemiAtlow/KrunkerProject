using Krunker.Common.Interfaces;
using System;
using System.Collections.Generic;

namespace Krunker.Common.Models
{
    public class ShoppingCart : IHasID
    {
        public Guid Id { get; set; }
        public double TotalPrice { get; set; }
        public bool PurchaseComplete { get; set; }
        public DateTime PurchaseTime { get; set; }
        public virtual ICollection<Purchase> Purchases { get; set; }
    }
}