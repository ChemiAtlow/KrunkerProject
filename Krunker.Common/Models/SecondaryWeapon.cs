using Krunker.Common.Enums;
using Krunker.Common.Interfaces;

namespace Krunker.Common.Models
{
    public class SecondaryWeapon : Weapon, IKnifeWeaponShoppingItem
    {
        public int KnifeLength { get; set; }
        public KnifeType TypeKnife { get; set; }
        public override ItemKind Kind => ItemKind.SecondaryWeapon;
    }
}
