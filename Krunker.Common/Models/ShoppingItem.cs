using Krunker.Common.Enums;
using Krunker.Common.Interfaces;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Krunker.Common.Models
{
    public class ShoppingItem : IShoppingItem
    {
        [Required(ErrorMessage = "Name is required!")]
        [StringLength(15, ErrorMessage = "{0} length must be between {2} and {1}.", MinimumLength = 3)]
        public string Name { get; set; }
        public string UriImg { get; set; }
        public int Discount { get; set; }
        [Required(ErrorMessage = "Price is required!")]
        public double Price { get; set; }
        public Guid Id { get; set; }
        public bool Archived { get; set; }

        public int CurrentAmount { get; set; }
        public virtual ICollection<Purchase> Purchases { get; set; }

        [NotMapped]
        public IFormFile Image { get; set; }

        public virtual ItemKind Kind => ItemKind.Unset;

        public void Add(int amount)
        {
            CurrentAmount += amount;
        }

        public bool Use(int amount)
        {
            if (CurrentAmount - amount < 0) return false;
            CurrentAmount -= amount;
            return true;
        }
    }
}
