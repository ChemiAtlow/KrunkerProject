using Krunker.Common.Enums;
using Krunker.Common.Models;
using Microsoft.AspNetCore.Http;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace Krunker.Common.Interfaces
{
    public interface IShoppingItem : IHasID, IArchivable, IAmountable
    {
        string Name { get; set; }
        string UriImg { get; set; }
        bool HasDiscount => Discount > 0;
        int Discount { get; set; }
        double Price { get; set; }
        double CalculatedPrice => Price - (Price * Discount / 100);
        ICollection<Purchase> Purchases { get; set; }
        ItemKind Kind { get; }

        [NotMapped]
        public IFormFile Image { get; set; }
    }
}
