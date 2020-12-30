using Krunker.Common.Interfaces;
using System.ComponentModel.DataAnnotations;

namespace Krunker.Common.Models
{
    public class Weapon : ShoppingItem, IWeaponShoppingItem
    {
        [Required]
        public string Creator { get; set; }
        public int Year { get; set; }
        public int FirePower { get; set; }
        public bool Automatic { get; set; }
    }
}
