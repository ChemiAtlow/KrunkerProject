using Krunker.Common.Enums;

namespace Krunker.Common.Interfaces
{
    public interface IKnifeWeaponShoppingItem : IWeaponShoppingItem
    {
        int KnifeLength { get; set; }
        KnifeType TypeKnife { get; set; }
    }
}
