using Krunker.Common.Enums;
using Krunker.Common.Interfaces;

namespace Krunker.Common.Models
{
    public class BackItem : ShoppingItem, IWingShoppingItem
    {
        public override ItemKind Kind => ItemKind.BackItem;
        public bool IsWings { get; set; }
    }
}
