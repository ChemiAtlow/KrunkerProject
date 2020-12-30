namespace Krunker.Common.Interfaces
{
    public interface IGunWeaponSoppingItem : IWeaponShoppingItem
    {
        int AmountBalls { get; set; }
        double ShootingRange { get; set; }
    }
}
