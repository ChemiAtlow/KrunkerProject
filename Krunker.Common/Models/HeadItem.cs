using Krunker.Common.Enums;
using Krunker.Common.Interfaces;

namespace Krunker.Common.Models
{
    public class HeadItem : ShoppingItem, IShoppingItem
    {
        public override ItemKind Kind => ItemKind.HeadItem;
    }
}