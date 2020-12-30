using Krunker.Common.Enums;
using Krunker.Common.Interfaces;

namespace Krunker.Common.Models
{
    public class PrimaryWeapon : Weapon, IGunWeaponSoppingItem
    {
        public int AmountBalls { get; set; }
        public double ShootingRange { get; set; }
        public override ItemKind Kind => ItemKind.PrimaryWeapon;
    }
}
