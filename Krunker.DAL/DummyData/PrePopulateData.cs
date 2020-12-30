using Krunker.Common.Enums;
using Krunker.Common.Models;
using System;

namespace Krunker.DAL.DummyData
{
    public static class PrePopulateData
    {
        /// <summary>
        /// Back Items to seed.
        /// </summary>
        public static readonly BackItem[] backItems =
        {
            new()
            {
                Id = Guid.NewGuid(),
                Name = "Diablo Wings",
                UriImg = "BackItem/DiabloWings.png",
                Price = 630.23,
                CurrentAmount = 10,
                IsWings = true
            },
            new()
            {
                Id = Guid.NewGuid(),
                Name = "Panda Body",
                UriImg = "BackItem/PandaBody.png",
                Price = 407.88,
                CurrentAmount = 10,
            },
            new()
            {
                Id = Guid.NewGuid(),
                Name = "Angeilc Wings",
                UriImg = "BackItem/AngeilcWings.png",
                Price = 580.92410,
                CurrentAmount = 10,
                IsWings = true
            },
            new()
            {
                Id = Guid.NewGuid(),
                Name = "Samurai Blades",
                UriImg = "BackItem/SamuraiBlades.png",
                Price = 714.7361238,
                CurrentAmount = 10,
            },
        };
        /// <summary>
        /// Head Items to seed.
        /// </summary>
        public static readonly HeadItem[] headItems = {
            new()
            {
                Id = Guid.NewGuid(),
                Name = "Afro",
                UriImg = "HeadItem/Afro.png",
                Price = 144.187,
                CurrentAmount = 120,
            },
            new()
            {
                Id = Guid.NewGuid(),
                Name = "Bandit",
                UriImg = "HeadItem/Bandit.png",
                Price = 173.253,
                CurrentAmount = 120,
            },
            new()
            {
                Id = Guid.NewGuid(),
                Name = "Clown",
                UriImg = "HeadItem/Clown.png",
                Price = 94.645,
                CurrentAmount = 120,
            },
            new()
            {
                Id = Guid.NewGuid(),
                Name = "Diuer Goggles",
                UriImg = "HeadItem/DiuerGoggles.png",
                Price = 97.412,
                CurrentAmount = 120,
            },
            new()
            {
                Id = Guid.NewGuid(),
                Name = "Jack o' Lantern",
                UriImg = "HeadItem/JackLantern.png",
                Price = 170.9814,
                CurrentAmount = 120,
            },
            new()
            {
                Id = Guid.NewGuid(),
                Name = "Mad Cap",
                UriImg = "HeadItem/MadCap.png",
                Price = 86.345,
                CurrentAmount = 120,
            },
            new()
            {
                Id = Guid.NewGuid(),
                Name = "MadMan",
                UriImg = "HeadItem/Madman.png",
                Price = 134.253,
                CurrentAmount = 120,
            },
            new()
            {
                Id = Guid.NewGuid(),
                Name = "Pig Head",
                UriImg = "HeadItem/PigHead.png",
                Price = 48.606,
                CurrentAmount = 120,
            },
            new()
            {
                Id = Guid.NewGuid(),
                Name = "Sun Glasses",
                UriImg = "HeadItem/SunGlasses.png",
                Price = 103.712,
                CurrentAmount = 120,
            },
            new()
            {
                Id = Guid.NewGuid(),
                Name = "Zombie Head",
                UriImg = "HeadItem/ZombieHead.png",
                Price = 230.87423,
                CurrentAmount = 120,
            },
        };
        /// <summary>
        /// Primary Weapons to seed.
        /// </summary>
        public static readonly PrimaryWeapon[] primaryWeapons = {
            new()
            {
                AmountBalls = 35,
                ShootingRange = 890.177,
                Creator = "IDF",
                Year = 2020,
                FirePower = 478,
                Automatic = true,
                Id = Guid.NewGuid(),
                Name = "Aqua",
                UriImg = "PrimaryWeapons/Aqua.png",
                Price = 612.4561,
                CurrentAmount = 88,
            },
            new()
            {
                AmountBalls = 29,
                ShootingRange = 5006.3,
                Creator = "Jhonny Depp",
                Year = 2016,
                FirePower = 225,
                Automatic = true,
                Id = Guid.NewGuid(),
                Name = "Cherry Blossom",
                UriImg = "PrimaryWeapons/CherryBlossom.png",
                Price = 456.613,
                CurrentAmount = 50,
            },
            new()
            {
                AmountBalls = 60,
                ShootingRange = 5504.2,
                Creator = "USA",
                Year = 2011,
                FirePower = 123,
                Automatic = true,
                Id = Guid.NewGuid(),
                Name = "Commo",
                UriImg = "PrimaryWeapons/Commo.png",
                Price = 650.100456,
                CurrentAmount = 50,
            },
            new()
            {
                AmountBalls = 29,
                ShootingRange = 5050.12,
                Creator = "France",
                Year = 2019,
                FirePower = 420,
                Automatic = true,
                Id = Guid.NewGuid(),
                Name = "Dijon",
                UriImg = "PrimaryWeapons/Dijon.png",
                Price = 336.23,
                CurrentAmount = 45,
            },
            new()
            {
                AmountBalls = 5,
                ShootingRange = 15000.0,
                Creator = "IDF",
                Year = 2020,
                FirePower = 1050,
                Automatic = false,
                Id = Guid.NewGuid(),
                Name = "Interuention Ul",
                UriImg = "PrimaryWeapons/InteruentionUl.png",
                Price = 525.718,
                CurrentAmount = 31,
            },
            new()
            {
                AmountBalls = 5,
                ShootingRange = 456.0,
                Creator = "Voca People",
                Year = 2020,
                FirePower = 630,
                Automatic = true,
                Id = Guid.NewGuid(),
                Name = "LMG Wanderer",
                UriImg = "PrimaryWeapons/LMGWanderer.png",
                Price = 850.147,
                CurrentAmount = 30,
            },
            new()
            {
                AmountBalls = 5,
                ShootingRange = 250.8,
                Creator = "Iraq",
                Year = 2020,
                FirePower = 1050,
                Automatic = false,
                Id = Guid.NewGuid(),
                Name = "Puma RR",
                UriImg = "PrimaryWeapons/PumaRR.png",
                Price = 472.454684,
                CurrentAmount = 48,
            },
            new()
            {
                AmountBalls = 5,
                ShootingRange = 149.40,
                Creator = "India",
                Year = 1987,
                FirePower = 983,
                Automatic = false,
                Id = Guid.NewGuid(),
                Name = "Spectrum",
                UriImg = "PrimaryWeapons/Spectrum.png",
                Price = 1322.942351,
                CurrentAmount = 4,
            },
            new()
            {
                AmountBalls = 37,
                ShootingRange = 15008.0,
                Creator = "USA",
                Year = 2018,
                FirePower = 945,
                Automatic = false,
                Id = Guid.NewGuid(),
                Name = "Theta",
                UriImg = "PrimaryWeapons/Theta.png",
                Price = 1048.723523,
                CurrentAmount = 12,
            },
        };
        /// <summary>
        /// Secondary Weapons to seed.
        /// </summary>
        public static readonly SecondaryWeapon[] secondaryWeapons = {
            new()
            {
                KnifeLength = 12,
                TypeKnife = KnifeType.Commando,
                Creator = "Idan Amedi",
                Year = 2018,
                FirePower = 20,
                Automatic = false,
                Id = Guid.NewGuid(),
                Name = "Flame Fang",
                UriImg = "SecondaryWeapons/FlameFang.png",
                Price = 84.5156,
                CurrentAmount = 103,
            },
            new()
            {
                KnifeLength = 16,
                TypeKnife = KnifeType.Leatherman,
                Creator = "Idan Raichel",
                Year = 2004,
                FirePower = 58,
                Automatic = false,
                Id = Guid.NewGuid(),
                Name = "Soul Fang",
                UriImg = "SecondaryWeapons/SoulFang.png",
                Price = 126.9753,
                CurrentAmount = 97,
            },
            new()
            {
                KnifeLength = 12,
                TypeKnife = KnifeType.Leatherman,
                Creator = "Idan Naim",
                Year = 2014,
                FirePower = 36,
                Automatic = false,
                Id = Guid.NewGuid(),
                Name = "Uolt Fang",
                UriImg = "SecondaryWeapons/UoltFang.png",
                Price = 74.8421,
                CurrentAmount = 86,
            },
        };
        /// <summary>
        /// Shopping Carts to seed.
        /// </summary>
        public static readonly ShoppingCart[] shoppingCarts = {
            new() {
                Id = Guid.NewGuid(),
                TotalPrice = 1126.598368,
                PurchaseTime = new DateTime(1592868506973),
                PurchaseComplete = true,
            },
            new() {
                Id = Guid.NewGuid(),
                TotalPrice = 1126.598368,
                PurchaseTime = new DateTime(1592870506973),
                PurchaseComplete = true,
            },
            new() {
                Id = Guid.NewGuid(),
                TotalPrice = 1126.598368,
                PurchaseTime = new DateTime(1592877506973),
                PurchaseComplete = true,
            },
            new() {
                Id = Guid.NewGuid(),
                TotalPrice = 1126.598368,
                PurchaseTime = new DateTime(1592878206973),
                PurchaseComplete = true,
            },
            new() {
                Id = Guid.NewGuid(),
                TotalPrice = 1396.631756944,
                PurchaseTime = new DateTime(1592978206973),
                PurchaseComplete = true,
            },
            new() {
                Id = Guid.NewGuid(),
                TotalPrice = 1386.252844944,
                PurchaseTime = new DateTime(1592988206973),
                PurchaseComplete = true,
            },
            new() {
                Id = Guid.NewGuid(),
                TotalPrice = 1396.631756944,
                PurchaseTime = new DateTime(1592999206973),
                PurchaseComplete = true,
            },
            new() {
                Id = Guid.NewGuid(),
                TotalPrice = 1396.631756944,
                PurchaseTime = new DateTime(1593084206973),
                PurchaseComplete = true,
            },
            new() {
                Id = Guid.NewGuid(),
                TotalPrice = 1396.631756944,
                PurchaseTime = new DateTime(1593884206973),
                PurchaseComplete = true,
            },
            new() {
                Id = Guid.NewGuid(),
                TotalPrice = 1470.126488944,
                PurchaseTime = new DateTime(1593954206973),
                PurchaseComplete = true,
            },
            new() {
                Id = Guid.NewGuid(),
                TotalPrice = 1470.126488944,
                PurchaseTime = new DateTime(1594959806973),
                PurchaseComplete = true,
            },
            new() {
                Id = Guid.NewGuid(),
                TotalPrice = 1163.898438944,
                PurchaseTime = new DateTime(1599959806973),
                PurchaseComplete = true,
            }
        };
        /// <summary>
        /// Purchases to seed.
        /// </summary>
        public static readonly Purchase[] purchases = {
            #region Cart 1
            new()
            {
                Id = Guid.NewGuid(),
                ShoppingCartId = shoppingCarts[0].Id,
                ItemId = backItems[1].Id,
                DiscountRate = 12,
                PriceAtPurchase = 407.88,
                Amount = 1
            },
            new()
            {
                Id = Guid.NewGuid(),
                ShoppingCartId = shoppingCarts[0].Id,
                ItemId = headItems[0].Id,
                DiscountRate = 0,
                PriceAtPurchase = 144.187,
                Amount = 1
            },
            new()
            {
                Id = Guid.NewGuid(),
                ShoppingCartId = shoppingCarts[0].Id,
                ItemId = primaryWeapons[0].Id,
                DiscountRate = 12,
                PriceAtPurchase = 612.4561,
                Amount = 1
            },
            new()
            {
                Id = Guid.NewGuid(),
                ShoppingCartId = shoppingCarts[0].Id,
                ItemId = secondaryWeapons[0].Id,
                DiscountRate = 0,
                PriceAtPurchase = 84.5156,
                Amount = 1
            },
            #endregion
            #region Cart 2
            new()
            {
                Id = Guid.NewGuid(),
                ShoppingCartId = shoppingCarts[1].Id,
                ItemId = backItems[1].Id,
                DiscountRate = 12,
                PriceAtPurchase = 407.88,
                Amount = 1
            },
            new()
            {
                Id = Guid.NewGuid(),
                ShoppingCartId = shoppingCarts[1].Id,
                ItemId = headItems[0].Id,
                DiscountRate = 0,
                PriceAtPurchase = 144.187,
                Amount = 1
            },
            new()
            {
                Id = Guid.NewGuid(),
                ShoppingCartId = shoppingCarts[1].Id,
                ItemId = primaryWeapons[0].Id,
                DiscountRate = 12,
                PriceAtPurchase = 612.4561,
                Amount = 1
            },
            new()
            {
                Id = Guid.NewGuid(),
                ShoppingCartId = shoppingCarts[1].Id,
                ItemId = secondaryWeapons[0].Id,
                DiscountRate = 0,
                PriceAtPurchase = 84.5156,
                Amount = 1
            },
            #endregion
            #region Cart 3
            new()
            {
                Id = Guid.NewGuid(),
                ShoppingCartId = shoppingCarts[2].Id,
                ItemId = backItems[1].Id,
                DiscountRate = 12,
                PriceAtPurchase = 407.88,
                Amount = 1
            },
            new()
            {
                Id = Guid.NewGuid(),
                ShoppingCartId = shoppingCarts[2].Id,
                ItemId = headItems[0].Id,
                DiscountRate = 0,
                PriceAtPurchase = 144.187,
                Amount = 1
            },
            new()
            {
                Id = Guid.NewGuid(),
                ShoppingCartId = shoppingCarts[2].Id,
                ItemId = primaryWeapons[0].Id,
                DiscountRate = 12,
                PriceAtPurchase = 612.4561,
                Amount = 1
            },
            new()
            {
                Id = Guid.NewGuid(),
                ShoppingCartId = shoppingCarts[2].Id,
                ItemId = secondaryWeapons[0].Id,
                DiscountRate = 0,
                PriceAtPurchase = 84.5156,
                Amount = 1
            },
            #endregion
            #region Cart 4
            new()
            {
                Id = Guid.NewGuid(),
                ShoppingCartId = shoppingCarts[3].Id,
                ItemId = backItems[1].Id,
                DiscountRate = 12,
                PriceAtPurchase = 407.88,
                Amount = 1
            },
            new()
            {
                Id = Guid.NewGuid(),
                ShoppingCartId = shoppingCarts[3].Id,
                ItemId = headItems[0].Id,
                DiscountRate = 0,
                PriceAtPurchase = 144.187,
                Amount = 1
            },
            new()
            {
                Id = Guid.NewGuid(),
                ShoppingCartId = shoppingCarts[3].Id,
                ItemId = primaryWeapons[0].Id,
                DiscountRate = 12,
                PriceAtPurchase = 612.4561,
                Amount = 1
            },
            new()
            {
                Id = Guid.NewGuid(),
                ShoppingCartId = shoppingCarts[3].Id,
                ItemId = secondaryWeapons[0].Id,
                DiscountRate = 0,
                PriceAtPurchase = 84.5156,
                Amount = 1
            },
            #endregion
            #region Cart 5
            new()
            {
                Id = Guid.NewGuid(),
                ShoppingCartId = shoppingCarts[4].Id,
                ItemId = backItems[3].Id,
                DiscountRate = 12,
                PriceAtPurchase = 714.7361238,
                Amount = 1
            },
            new()
            {
                Id = Guid.NewGuid(),
                ShoppingCartId = shoppingCarts[4].Id,
                ItemId = headItems[0].Id,
                DiscountRate = 0,
                PriceAtPurchase = 144.187,
                Amount = 1
            },
            new()
            {
                Id = Guid.NewGuid(),
                ShoppingCartId = shoppingCarts[4].Id,
                ItemId = primaryWeapons[0].Id,
                DiscountRate = 12,
                PriceAtPurchase = 612.4561,
                Amount = 1
            },
            new()
            {
                Id = Guid.NewGuid(),
                ShoppingCartId = shoppingCarts[4].Id,
                ItemId = secondaryWeapons[0].Id,
                DiscountRate = 0,
                PriceAtPurchase = 84.5156,
                Amount = 1
            },
            #endregion
            #region Cart 6
            new()
            {
                Id = Guid.NewGuid(),
                ShoppingCartId = shoppingCarts[5].Id,
                ItemId = backItems[3].Id,
                DiscountRate = 12,
                PriceAtPurchase = 714.7361238,
                Amount = 1
            },
            new()
            {
                Id = Guid.NewGuid(),
                ShoppingCartId = shoppingCarts[5].Id,
                ItemId = headItems[1].Id,
                DiscountRate = 12,
                PriceAtPurchase = 173.253,
                Amount = 1
            },
            new()
            {
                Id = Guid.NewGuid(),
                ShoppingCartId = shoppingCarts[5].Id,
                ItemId = primaryWeapons[0].Id,
                DiscountRate = 12,
                PriceAtPurchase = 612.4561,
                Amount = 1
            },
            new()
            {
                Id = Guid.NewGuid(),
                ShoppingCartId = shoppingCarts[5].Id,
                ItemId = secondaryWeapons[2].Id,
                DiscountRate = 0,
                PriceAtPurchase = 84.5156,
                Amount = 1
            },
            #endregion
            #region Cart 7
            new()
            {
                Id = Guid.NewGuid(),
                ShoppingCartId = shoppingCarts[6].Id,
                ItemId = backItems[3].Id,
                DiscountRate = 12,
                PriceAtPurchase = 714.7361238,
                Amount = 1
            },
            new()
            {
                Id = Guid.NewGuid(),
                ShoppingCartId = shoppingCarts[6].Id,
                ItemId = headItems[0].Id,
                DiscountRate = 0,
                PriceAtPurchase = 144.187,
                Amount = 1
            },
            new()
            {
                Id = Guid.NewGuid(),
                ShoppingCartId = shoppingCarts[6].Id,
                ItemId = primaryWeapons[0].Id,
                DiscountRate = 12,
                PriceAtPurchase = 612.4561,
                Amount = 1
            },
            new()
            {
                Id = Guid.NewGuid(),
                ShoppingCartId = shoppingCarts[6].Id,
                ItemId = secondaryWeapons[0].Id,
                DiscountRate = 0,
                PriceAtPurchase = 84.5156,
                Amount = 1
            },
            #endregion
            #region Cart 8
            new()
            {
                Id = Guid.NewGuid(),
                ShoppingCartId = shoppingCarts[7].Id,
                ItemId = backItems[3].Id,
                DiscountRate = 12,
                PriceAtPurchase = 714.7361238,
                Amount = 1
            },
            new()
            {
                Id = Guid.NewGuid(),
                ShoppingCartId = shoppingCarts[7].Id,
                ItemId = headItems[0].Id,
                DiscountRate = 0,
                PriceAtPurchase = 144.187,
                Amount = 1
            },
            new()
            {
                Id = Guid.NewGuid(),
                ShoppingCartId = shoppingCarts[7].Id,
                ItemId = primaryWeapons[0].Id,
                DiscountRate = 12,
                PriceAtPurchase = 612.4561,
                Amount = 1
            },
            new()
            {
                Id = Guid.NewGuid(),
                ShoppingCartId = shoppingCarts[7].Id,
                ItemId = secondaryWeapons[0].Id,
                DiscountRate = 0,
                PriceAtPurchase = 84.5156,
                Amount = 1
            },
            #endregion
            #region Cart 9
            new()
            {
                Id = Guid.NewGuid(),
                ShoppingCartId = shoppingCarts[8].Id,
                ItemId = backItems[3].Id,
                DiscountRate = 12,
                PriceAtPurchase = 714.7361238,
                Amount = 1
            },
            new()
            {
                Id = Guid.NewGuid(),
                ShoppingCartId = shoppingCarts[8].Id,
                ItemId = headItems[0].Id,
                DiscountRate = 0,
                PriceAtPurchase = 144.187,
                Amount = 1
            },
            new()
            {
                Id = Guid.NewGuid(),
                ShoppingCartId = shoppingCarts[8].Id,
                ItemId = primaryWeapons[0].Id,
                DiscountRate = 12,
                PriceAtPurchase = 612.4561,
                Amount = 1
            },
            new()
            {
                Id = Guid.NewGuid(),
                ShoppingCartId = shoppingCarts[8].Id,
                ItemId = secondaryWeapons[0].Id,
                DiscountRate = 0,
                PriceAtPurchase = 84.5156,
                Amount = 1
            },
            #endregion
            #region Cart 10
            new()
            {
                Id = Guid.NewGuid(),
                ShoppingCartId = shoppingCarts[9].Id,
                ItemId = backItems[3].Id,
                DiscountRate = 12,
                PriceAtPurchase = 714.7361238,
                Amount = 1
            },
            new()
            {
                Id = Guid.NewGuid(),
                ShoppingCartId = shoppingCarts[9].Id,
                ItemId = headItems[0].Id,
                DiscountRate = 0,
                PriceAtPurchase = 144.187,
                Amount = 1
            },
            new()
            {
                Id = Guid.NewGuid(),
                ShoppingCartId = shoppingCarts[9].Id,
                ItemId = primaryWeapons[0].Id,
                DiscountRate = 0,
                PriceAtPurchase = 612.4561,
                Amount = 1
            },
            new()
            {
                Id = Guid.NewGuid(),
                ShoppingCartId = shoppingCarts[9].Id,
                ItemId = secondaryWeapons[0].Id,
                DiscountRate = 0,
                PriceAtPurchase = 84.5156,
                Amount = 1
            },
            #endregion
            #region Cart 11
            new()
            {
                Id = Guid.NewGuid(),
                ShoppingCartId = shoppingCarts[10].Id,
                ItemId = backItems[3].Id,
                DiscountRate = 12,
                PriceAtPurchase = 714.7361238,
                Amount = 1
            },
            new()
            {
                Id = Guid.NewGuid(),
                ShoppingCartId = shoppingCarts[10].Id,
                ItemId = headItems[0].Id,
                DiscountRate = 0,
                PriceAtPurchase = 144.187,
                Amount = 1
            },
            new()
            {
                Id = Guid.NewGuid(),
                ShoppingCartId = shoppingCarts[10].Id,
                ItemId = primaryWeapons[0].Id,
                DiscountRate = 0,
                PriceAtPurchase = 612.4561,
                Amount = 1
            },
            new()
            {
                Id = Guid.NewGuid(),
                ShoppingCartId = shoppingCarts[10].Id,
                ItemId = secondaryWeapons[0].Id,
                DiscountRate = 0,
                PriceAtPurchase = 84.5156,
                Amount = 1
            },
            #endregion
            #region Cart 12
            new()
            {
                Id = Guid.NewGuid(),
                ShoppingCartId = shoppingCarts[11].Id,
                ItemId = backItems[3].Id,
                DiscountRate = 12,
                PriceAtPurchase = 714.7361238,
                Amount = 1
            },
            new()
            {
                Id = Guid.NewGuid(),
                ShoppingCartId = shoppingCarts[11].Id,
                ItemId = headItems[0].Id,
                DiscountRate = 0,
                PriceAtPurchase = 144.187,
                Amount = 1
            },
            new()
            {
                Id = Guid.NewGuid(),
                ShoppingCartId = shoppingCarts[11].Id,
                ItemId = primaryWeapons[0].Id,
                DiscountRate = 50,
                PriceAtPurchase = 612.4561,
                Amount = 1
            },
            new()
            {
                Id = Guid.NewGuid(),
                ShoppingCartId = shoppingCarts[11].Id,
                ItemId = secondaryWeapons[0].Id,
                DiscountRate = 0,
                PriceAtPurchase = 84.5156,
                Amount = 1
            },
            #endregion
        };
    }
}
