namespace Krunker.Common.Interfaces
{
    public interface IWeaponShoppingItem : IShoppingItem
    {
        string Creator { get; set; }
        int Year { get; set; }
        int FirePower { get; set; }
        bool Automatic { get; set; }
    }
}
