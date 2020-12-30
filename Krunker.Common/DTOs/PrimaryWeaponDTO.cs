using Krunker.Common.Models;

namespace Krunker.Common.DTOs
{
    public class PrimaryWeaponDTO : WeaponDTO
    {
        public int AmountBalls { get; set; }
        public double ShootingRange { get; set; }

        public PrimaryWeaponDTO(PrimaryWeapon item) : base(item)
        {
            AmountBalls = item.AmountBalls;
            ShootingRange = item.ShootingRange;
        }
    }
}
