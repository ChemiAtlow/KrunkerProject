using Krunker.Common.Enums;
using Krunker.Common.Models;

namespace Krunker.Common.DTOs
{
    public class SecondaryWeaponDTO : WeaponDTO
    {
        public int KnifeLength { get; set; }
        public KnifeType TypeKnife { get; set; }

        public SecondaryWeaponDTO(SecondaryWeapon item) : base(item)
        {
            KnifeLength = item.KnifeLength;
            TypeKnife = item.TypeKnife;
        }
    }
}
