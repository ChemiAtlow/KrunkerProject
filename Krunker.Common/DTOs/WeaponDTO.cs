using Krunker.Common.Interfaces;

namespace Krunker.Common.DTOs
{
    public class WeaponDTO : ShoppingItemDTO
    {
        public string Creator { get; init; }
        public int Year { get; init; }
        public int FirePower { get; init; }
        public bool Automatic { get; init; }

        public WeaponDTO(IWeaponShoppingItem item) : base(item)
        {
            Creator = item.Creator;
            Year = item.Year;
            FirePower = item.FirePower;
            Automatic = item.Automatic;
        }
    }
}
