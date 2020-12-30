using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Krunker.DAL.Migrations
{
    public partial class Init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ShoppingCarts",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    TotalPrice = table.Column<double>(type: "REAL", nullable: false),
                    PurchaseComplete = table.Column<bool>(type: "INTEGER", nullable: false),
                    PurchaseTime = table.Column<DateTime>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ShoppingCarts", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ShoppingItem",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    Name = table.Column<string>(type: "TEXT", maxLength: 15, nullable: false),
                    UriImg = table.Column<string>(type: "TEXT", nullable: true),
                    Discount = table.Column<int>(type: "INTEGER", nullable: false),
                    Price = table.Column<double>(type: "REAL", nullable: false),
                    Archived = table.Column<bool>(type: "INTEGER", nullable: false),
                    CurrentAmount = table.Column<int>(type: "INTEGER", nullable: false),
                    Discriminator = table.Column<string>(type: "TEXT", nullable: false),
                    IsWings = table.Column<bool>(type: "INTEGER", nullable: true),
                    AmountBalls = table.Column<int>(type: "INTEGER", nullable: true),
                    ShootingRange = table.Column<double>(type: "REAL", nullable: true),
                    PrimaryWeapon_Creator = table.Column<string>(type: "TEXT", nullable: true),
                    PrimaryWeapon_Year = table.Column<int>(type: "INTEGER", nullable: true),
                    PrimaryWeapon_FirePower = table.Column<int>(type: "INTEGER", nullable: true),
                    PrimaryWeapon_Automatic = table.Column<bool>(type: "INTEGER", nullable: true),
                    KnifeLength = table.Column<int>(type: "INTEGER", nullable: true),
                    TypeKnife = table.Column<int>(type: "INTEGER", nullable: true),
                    Creator = table.Column<string>(type: "TEXT", nullable: true),
                    Year = table.Column<int>(type: "INTEGER", nullable: true),
                    FirePower = table.Column<int>(type: "INTEGER", nullable: true),
                    Automatic = table.Column<bool>(type: "INTEGER", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ShoppingItem", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Purchases",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    ItemId = table.Column<Guid>(type: "TEXT", nullable: false),
                    ShoppingCartId = table.Column<Guid>(type: "TEXT", nullable: false),
                    Amount = table.Column<int>(type: "INTEGER", nullable: false),
                    DiscountRate = table.Column<double>(type: "REAL", nullable: false),
                    PriceAtPurchase = table.Column<double>(type: "REAL", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Purchases", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Purchases_ShoppingCarts_ShoppingCartId",
                        column: x => x.ShoppingCartId,
                        principalTable: "ShoppingCarts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Purchases_ShoppingItem_ItemId",
                        column: x => x.ItemId,
                        principalTable: "ShoppingItem",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "ShoppingCarts",
                columns: new[] { "Id", "PurchaseComplete", "PurchaseTime", "TotalPrice" },
                values: new object[] { new Guid("7ea669b1-c896-472a-b3ae-441ab6d53012"), true, new DateTime(1, 1, 2, 20, 26, 35, 980, DateTimeKind.Unspecified).AddTicks(6973), 1163.898438944 });

            migrationBuilder.InsertData(
                table: "ShoppingCarts",
                columns: new[] { "Id", "PurchaseComplete", "PurchaseTime", "TotalPrice" },
                values: new object[] { new Guid("6959a3f5-fe27-43ce-8728-e987f9dde300"), true, new DateTime(1, 1, 2, 20, 14, 46, 850, DateTimeKind.Unspecified).AddTicks(6973), 1126.5983679999999 });

            migrationBuilder.InsertData(
                table: "ShoppingCarts",
                columns: new[] { "Id", "PurchaseComplete", "PurchaseTime", "TotalPrice" },
                values: new object[] { new Guid("e4c52648-bd1f-4464-991b-7d0083d2c5a1"), true, new DateTime(1, 1, 2, 20, 14, 47, 750, DateTimeKind.Unspecified).AddTicks(6973), 1126.5983679999999 });

            migrationBuilder.InsertData(
                table: "ShoppingCarts",
                columns: new[] { "Id", "PurchaseComplete", "PurchaseTime", "TotalPrice" },
                values: new object[] { new Guid("6053c15c-7316-4405-9eaf-43100e18f514"), true, new DateTime(1, 1, 2, 20, 14, 47, 820, DateTimeKind.Unspecified).AddTicks(6973), 1126.5983679999999 });

            migrationBuilder.InsertData(
                table: "ShoppingCarts",
                columns: new[] { "Id", "PurchaseComplete", "PurchaseTime", "TotalPrice" },
                values: new object[] { new Guid("c1b9e69f-3b27-4e5b-bb78-a6c1c83fea11"), true, new DateTime(1, 1, 2, 20, 14, 57, 820, DateTimeKind.Unspecified).AddTicks(6973), 1396.631756944 });

            migrationBuilder.InsertData(
                table: "ShoppingCarts",
                columns: new[] { "Id", "PurchaseComplete", "PurchaseTime", "TotalPrice" },
                values: new object[] { new Guid("d1c2d163-5358-49e1-84c1-9cda5faa2852"), true, new DateTime(1, 1, 2, 20, 14, 47, 50, DateTimeKind.Unspecified).AddTicks(6973), 1126.5983679999999 });

            migrationBuilder.InsertData(
                table: "ShoppingCarts",
                columns: new[] { "Id", "PurchaseComplete", "PurchaseTime", "TotalPrice" },
                values: new object[] { new Guid("1bb3315e-ee7f-4688-acfa-ca1c5a3f980b"), true, new DateTime(1, 1, 2, 20, 14, 59, 920, DateTimeKind.Unspecified).AddTicks(6973), 1396.631756944 });

            migrationBuilder.InsertData(
                table: "ShoppingCarts",
                columns: new[] { "Id", "PurchaseComplete", "PurchaseTime", "TotalPrice" },
                values: new object[] { new Guid("cf9b6fc3-df40-4cb1-af5c-f1194f468e2c"), true, new DateTime(1, 1, 2, 20, 15, 8, 420, DateTimeKind.Unspecified).AddTicks(6973), 1396.631756944 });

            migrationBuilder.InsertData(
                table: "ShoppingCarts",
                columns: new[] { "Id", "PurchaseComplete", "PurchaseTime", "TotalPrice" },
                values: new object[] { new Guid("e6227559-7ce3-4816-aad7-6d16dbf5f508"), true, new DateTime(1, 1, 2, 20, 16, 28, 420, DateTimeKind.Unspecified).AddTicks(6973), 1396.631756944 });

            migrationBuilder.InsertData(
                table: "ShoppingCarts",
                columns: new[] { "Id", "PurchaseComplete", "PurchaseTime", "TotalPrice" },
                values: new object[] { new Guid("8ea25f16-137d-4fa7-a9a2-e7fa993e53da"), true, new DateTime(1, 1, 2, 20, 16, 35, 420, DateTimeKind.Unspecified).AddTicks(6973), 1470.1264889439999 });

            migrationBuilder.InsertData(
                table: "ShoppingCarts",
                columns: new[] { "Id", "PurchaseComplete", "PurchaseTime", "TotalPrice" },
                values: new object[] { new Guid("cb20886a-380d-4368-a419-a0c4990ed2d6"), true, new DateTime(1, 1, 2, 20, 14, 58, 820, DateTimeKind.Unspecified).AddTicks(6973), 1386.2528449439999 });

            migrationBuilder.InsertData(
                table: "ShoppingCarts",
                columns: new[] { "Id", "PurchaseComplete", "PurchaseTime", "TotalPrice" },
                values: new object[] { new Guid("0735abdb-1fa2-4598-bb01-2ac4afffa251"), true, new DateTime(1, 1, 2, 20, 18, 15, 980, DateTimeKind.Unspecified).AddTicks(6973), 1470.1264889439999 });

            migrationBuilder.InsertData(
                table: "ShoppingItem",
                columns: new[] { "Id", "AmountBalls", "Archived", "PrimaryWeapon_Automatic", "PrimaryWeapon_Creator", "CurrentAmount", "Discount", "Discriminator", "PrimaryWeapon_FirePower", "Name", "Price", "ShootingRange", "UriImg", "PrimaryWeapon_Year" },
                values: new object[] { new Guid("596e7611-6ea3-446d-89ad-4b976404e846"), 5, false, true, "Voca People", 30, 0, "PrimaryWeapon", 630, "LMG Wanderer", 850.14700000000005, 456.0, "PrimaryWeapons/LMGWanderer.png", 2020 });

            migrationBuilder.InsertData(
                table: "ShoppingItem",
                columns: new[] { "Id", "Archived", "Automatic", "Creator", "CurrentAmount", "Discount", "Discriminator", "FirePower", "KnifeLength", "Name", "Price", "TypeKnife", "UriImg", "Year" },
                values: new object[] { new Guid("1e3994f6-3810-4f38-ad31-6779a169b415"), false, false, "Idan Naim", 86, 0, "SecondaryWeapon", 36, 12, "Uolt Fang", 74.842100000000002, 1, "SecondaryWeapons/UoltFang.png", 2014 });

            migrationBuilder.InsertData(
                table: "ShoppingItem",
                columns: new[] { "Id", "Archived", "Automatic", "Creator", "CurrentAmount", "Discount", "Discriminator", "FirePower", "KnifeLength", "Name", "Price", "TypeKnife", "UriImg", "Year" },
                values: new object[] { new Guid("675f5421-1641-403a-b967-b1548496fc20"), false, false, "Idan Raichel", 97, 0, "SecondaryWeapon", 58, 16, "Soul Fang", 126.9753, 1, "SecondaryWeapons/SoulFang.png", 2004 });

            migrationBuilder.InsertData(
                table: "ShoppingItem",
                columns: new[] { "Id", "Archived", "Automatic", "Creator", "CurrentAmount", "Discount", "Discriminator", "FirePower", "KnifeLength", "Name", "Price", "TypeKnife", "UriImg", "Year" },
                values: new object[] { new Guid("eb415d68-8d73-4135-90a4-e02cc7d66dd5"), false, false, "Idan Amedi", 103, 0, "SecondaryWeapon", 20, 12, "Flame Fang", 84.515600000000006, 0, "SecondaryWeapons/FlameFang.png", 2018 });

            migrationBuilder.InsertData(
                table: "ShoppingItem",
                columns: new[] { "Id", "AmountBalls", "Archived", "PrimaryWeapon_Automatic", "PrimaryWeapon_Creator", "CurrentAmount", "Discount", "Discriminator", "PrimaryWeapon_FirePower", "Name", "Price", "ShootingRange", "UriImg", "PrimaryWeapon_Year" },
                values: new object[] { new Guid("6ac75aad-9f02-4fbc-bcb0-12d48bd87cbe"), 37, false, false, "USA", 12, 0, "PrimaryWeapon", 945, "Theta", 1048.7235229999999, 15008.0, "PrimaryWeapons/Theta.png", 2018 });

            migrationBuilder.InsertData(
                table: "ShoppingItem",
                columns: new[] { "Id", "AmountBalls", "Archived", "PrimaryWeapon_Automatic", "PrimaryWeapon_Creator", "CurrentAmount", "Discount", "Discriminator", "PrimaryWeapon_FirePower", "Name", "Price", "ShootingRange", "UriImg", "PrimaryWeapon_Year" },
                values: new object[] { new Guid("423c95f9-3e68-4ade-ab18-21e40f8ae5fe"), 5, false, false, "India", 4, 0, "PrimaryWeapon", 983, "Spectrum", 1322.9423509999999, 149.40000000000001, "PrimaryWeapons/Spectrum.png", 1987 });

            migrationBuilder.InsertData(
                table: "ShoppingItem",
                columns: new[] { "Id", "AmountBalls", "Archived", "PrimaryWeapon_Automatic", "PrimaryWeapon_Creator", "CurrentAmount", "Discount", "Discriminator", "PrimaryWeapon_FirePower", "Name", "Price", "ShootingRange", "UriImg", "PrimaryWeapon_Year" },
                values: new object[] { new Guid("13becbc4-a6f3-47bb-91b6-ec3716373571"), 5, false, false, "Iraq", 48, 0, "PrimaryWeapon", 1050, "Puma RR", 472.45468399999999, 250.80000000000001, "PrimaryWeapons/PumaRR.png", 2020 });

            migrationBuilder.InsertData(
                table: "ShoppingItem",
                columns: new[] { "Id", "AmountBalls", "Archived", "PrimaryWeapon_Automatic", "PrimaryWeapon_Creator", "CurrentAmount", "Discount", "Discriminator", "PrimaryWeapon_FirePower", "Name", "Price", "ShootingRange", "UriImg", "PrimaryWeapon_Year" },
                values: new object[] { new Guid("7dc6bbb8-2e78-4fc2-a29a-981e55007777"), 5, false, false, "IDF", 31, 0, "PrimaryWeapon", 1050, "Interuention Ul", 525.71799999999996, 15000.0, "PrimaryWeapons/InteruentionUl.png", 2020 });

            migrationBuilder.InsertData(
                table: "ShoppingItem",
                columns: new[] { "Id", "AmountBalls", "Archived", "PrimaryWeapon_Automatic", "PrimaryWeapon_Creator", "CurrentAmount", "Discount", "Discriminator", "PrimaryWeapon_FirePower", "Name", "Price", "ShootingRange", "UriImg", "PrimaryWeapon_Year" },
                values: new object[] { new Guid("e6d83d26-9d48-41d0-9d24-a36f484d354c"), 60, false, true, "USA", 50, 0, "PrimaryWeapon", 123, "Commo", 650.10045600000001, 5504.1999999999998, "PrimaryWeapons/Commo.png", 2011 });

            migrationBuilder.InsertData(
                table: "ShoppingItem",
                columns: new[] { "Id", "Archived", "CurrentAmount", "Discount", "Discriminator", "IsWings", "Name", "Price", "UriImg" },
                values: new object[] { new Guid("75ccf681-e4b9-4772-97eb-39c61d44ed45"), false, 10, 0, "BackItem", false, "Panda Body", 407.88, "BackItem/PandaBody.png" });

            migrationBuilder.InsertData(
                table: "ShoppingItem",
                columns: new[] { "Id", "Archived", "CurrentAmount", "Discount", "Discriminator", "IsWings", "Name", "Price", "UriImg" },
                values: new object[] { new Guid("b2a90bde-23b2-49a5-bf03-499f2c079a5e"), false, 10, 0, "BackItem", true, "Angeilc Wings", 580.92409999999995, "BackItem/AngeilcWings.png" });

            migrationBuilder.InsertData(
                table: "ShoppingItem",
                columns: new[] { "Id", "Archived", "CurrentAmount", "Discount", "Discriminator", "IsWings", "Name", "Price", "UriImg" },
                values: new object[] { new Guid("4b4bc481-6362-4a50-990f-97870cd5f61e"), false, 10, 0, "BackItem", false, "Samurai Blades", 714.73612379999997, "BackItem/SamuraiBlades.png" });

            migrationBuilder.InsertData(
                table: "ShoppingItem",
                columns: new[] { "Id", "Archived", "CurrentAmount", "Discount", "Discriminator", "Name", "Price", "UriImg" },
                values: new object[] { new Guid("ac5121c3-6215-4475-8c2c-9559dec2db4d"), false, 120, 0, "HeadItem", "Afro", 144.18700000000001, "HeadItem/Afro.png" });

            migrationBuilder.InsertData(
                table: "ShoppingItem",
                columns: new[] { "Id", "Archived", "CurrentAmount", "Discount", "Discriminator", "Name", "Price", "UriImg" },
                values: new object[] { new Guid("4ca15527-db80-4337-8b22-7309c02fe08f"), false, 120, 0, "HeadItem", "Bandit", 173.25299999999999, "HeadItem/Bandit.png" });

            migrationBuilder.InsertData(
                table: "ShoppingItem",
                columns: new[] { "Id", "Archived", "CurrentAmount", "Discount", "Discriminator", "Name", "Price", "UriImg" },
                values: new object[] { new Guid("e51aff66-9d59-4327-87b8-dec4b8f7b125"), false, 120, 0, "HeadItem", "Clown", 94.644999999999996, "HeadItem/Clown.png" });

            migrationBuilder.InsertData(
                table: "ShoppingItem",
                columns: new[] { "Id", "Archived", "CurrentAmount", "Discount", "Discriminator", "Name", "Price", "UriImg" },
                values: new object[] { new Guid("462cd6fb-7a69-4ed2-a74e-477e16519c16"), false, 120, 0, "HeadItem", "Diuer Goggles", 97.412000000000006, "HeadItem/DiuerGoggles.png" });

            migrationBuilder.InsertData(
                table: "ShoppingItem",
                columns: new[] { "Id", "Archived", "CurrentAmount", "Discount", "Discriminator", "Name", "Price", "UriImg" },
                values: new object[] { new Guid("daec6e75-1e0c-4039-ad62-b49d96a0807f"), false, 120, 0, "HeadItem", "Jack o' Lantern", 170.98140000000001, "HeadItem/JackLantern.png" });

            migrationBuilder.InsertData(
                table: "ShoppingItem",
                columns: new[] { "Id", "Archived", "CurrentAmount", "Discount", "Discriminator", "Name", "Price", "UriImg" },
                values: new object[] { new Guid("944f109e-d36e-4679-bc59-9c0db7148c0e"), false, 120, 0, "HeadItem", "Mad Cap", 86.344999999999999, "HeadItem/MadCap.png" });

            migrationBuilder.InsertData(
                table: "ShoppingItem",
                columns: new[] { "Id", "Archived", "CurrentAmount", "Discount", "Discriminator", "Name", "Price", "UriImg" },
                values: new object[] { new Guid("062c2c92-390e-4df6-bddf-26f40ccde370"), false, 120, 0, "HeadItem", "MadMan", 134.25299999999999, "HeadItem/Madman.png" });

            migrationBuilder.InsertData(
                table: "ShoppingItem",
                columns: new[] { "Id", "Archived", "CurrentAmount", "Discount", "Discriminator", "Name", "Price", "UriImg" },
                values: new object[] { new Guid("11bb3e65-595a-473f-8171-e6ce9984bebe"), false, 120, 0, "HeadItem", "Pig Head", 48.606000000000002, "HeadItem/PigHead.png" });

            migrationBuilder.InsertData(
                table: "ShoppingItem",
                columns: new[] { "Id", "Archived", "CurrentAmount", "Discount", "Discriminator", "Name", "Price", "UriImg" },
                values: new object[] { new Guid("5b28fd2c-5d2e-4fa0-a3de-0617af5eff19"), false, 120, 0, "HeadItem", "Sun Glasses", 103.712, "HeadItem/SunGlasses.png" });

            migrationBuilder.InsertData(
                table: "ShoppingItem",
                columns: new[] { "Id", "Archived", "CurrentAmount", "Discount", "Discriminator", "Name", "Price", "UriImg" },
                values: new object[] { new Guid("f78cdb47-44df-4e40-b6bb-148165c8d50b"), false, 120, 0, "HeadItem", "Zombie Head", 230.87423000000001, "HeadItem/ZombieHead.png" });

            migrationBuilder.InsertData(
                table: "ShoppingItem",
                columns: new[] { "Id", "AmountBalls", "Archived", "PrimaryWeapon_Automatic", "PrimaryWeapon_Creator", "CurrentAmount", "Discount", "Discriminator", "PrimaryWeapon_FirePower", "Name", "Price", "ShootingRange", "UriImg", "PrimaryWeapon_Year" },
                values: new object[] { new Guid("78e0e6d9-02a8-46fa-8135-5891ac904db2"), 35, false, true, "IDF", 88, 0, "PrimaryWeapon", 478, "Aqua", 612.45609999999999, 890.17700000000002, "PrimaryWeapons/Aqua.png", 2020 });

            migrationBuilder.InsertData(
                table: "ShoppingItem",
                columns: new[] { "Id", "AmountBalls", "Archived", "PrimaryWeapon_Automatic", "PrimaryWeapon_Creator", "CurrentAmount", "Discount", "Discriminator", "PrimaryWeapon_FirePower", "Name", "Price", "ShootingRange", "UriImg", "PrimaryWeapon_Year" },
                values: new object[] { new Guid("f769e2f8-edd9-4ee6-b884-930d25865d89"), 29, false, true, "Jhonny Depp", 50, 0, "PrimaryWeapon", 225, "Cherry Blossom", 456.613, 5006.3000000000002, "PrimaryWeapons/CherryBlossom.png", 2016 });

            migrationBuilder.InsertData(
                table: "ShoppingItem",
                columns: new[] { "Id", "AmountBalls", "Archived", "PrimaryWeapon_Automatic", "PrimaryWeapon_Creator", "CurrentAmount", "Discount", "Discriminator", "PrimaryWeapon_FirePower", "Name", "Price", "ShootingRange", "UriImg", "PrimaryWeapon_Year" },
                values: new object[] { new Guid("4ea88879-6716-4182-b0a4-cd9434dab5a4"), 29, false, true, "France", 45, 0, "PrimaryWeapon", 420, "Dijon", 336.23000000000002, 5050.1199999999999, "PrimaryWeapons/Dijon.png", 2019 });

            migrationBuilder.InsertData(
                table: "ShoppingItem",
                columns: new[] { "Id", "Archived", "CurrentAmount", "Discount", "Discriminator", "IsWings", "Name", "Price", "UriImg" },
                values: new object[] { new Guid("1af020e5-fa5f-4fc3-aa6b-10ba2ea8c210"), false, 10, 0, "BackItem", true, "Diablo Wings", 630.23000000000002, "BackItem/DiabloWings.png" });

            migrationBuilder.InsertData(
                table: "Purchases",
                columns: new[] { "Id", "Amount", "DiscountRate", "ItemId", "PriceAtPurchase", "ShoppingCartId" },
                values: new object[] { new Guid("8a6ca8ca-82c0-4fab-8358-b0023a1b05dd"), 1, 12.0, new Guid("75ccf681-e4b9-4772-97eb-39c61d44ed45"), 407.88, new Guid("6959a3f5-fe27-43ce-8728-e987f9dde300") });

            migrationBuilder.InsertData(
                table: "Purchases",
                columns: new[] { "Id", "Amount", "DiscountRate", "ItemId", "PriceAtPurchase", "ShoppingCartId" },
                values: new object[] { new Guid("601d30e1-62fa-4363-a0ad-163ad572e297"), 1, 12.0, new Guid("78e0e6d9-02a8-46fa-8135-5891ac904db2"), 612.45609999999999, new Guid("1bb3315e-ee7f-4688-acfa-ca1c5a3f980b") });

            migrationBuilder.InsertData(
                table: "Purchases",
                columns: new[] { "Id", "Amount", "DiscountRate", "ItemId", "PriceAtPurchase", "ShoppingCartId" },
                values: new object[] { new Guid("4ea35239-613e-443f-ab29-13ca5c16cb37"), 1, 0.0, new Guid("eb415d68-8d73-4135-90a4-e02cc7d66dd5"), 84.515600000000006, new Guid("1bb3315e-ee7f-4688-acfa-ca1c5a3f980b") });

            migrationBuilder.InsertData(
                table: "Purchases",
                columns: new[] { "Id", "Amount", "DiscountRate", "ItemId", "PriceAtPurchase", "ShoppingCartId" },
                values: new object[] { new Guid("d6821127-9a6b-4951-a9e1-2c3639104ce4"), 1, 12.0, new Guid("4b4bc481-6362-4a50-990f-97870cd5f61e"), 714.73612379999997, new Guid("cf9b6fc3-df40-4cb1-af5c-f1194f468e2c") });

            migrationBuilder.InsertData(
                table: "Purchases",
                columns: new[] { "Id", "Amount", "DiscountRate", "ItemId", "PriceAtPurchase", "ShoppingCartId" },
                values: new object[] { new Guid("748708f2-e442-4fbb-a8b6-fbcdb77c460b"), 1, 0.0, new Guid("ac5121c3-6215-4475-8c2c-9559dec2db4d"), 144.18700000000001, new Guid("cf9b6fc3-df40-4cb1-af5c-f1194f468e2c") });

            migrationBuilder.InsertData(
                table: "Purchases",
                columns: new[] { "Id", "Amount", "DiscountRate", "ItemId", "PriceAtPurchase", "ShoppingCartId" },
                values: new object[] { new Guid("f8236fdc-a48d-421d-875b-b0ff43610603"), 1, 12.0, new Guid("78e0e6d9-02a8-46fa-8135-5891ac904db2"), 612.45609999999999, new Guid("cf9b6fc3-df40-4cb1-af5c-f1194f468e2c") });

            migrationBuilder.InsertData(
                table: "Purchases",
                columns: new[] { "Id", "Amount", "DiscountRate", "ItemId", "PriceAtPurchase", "ShoppingCartId" },
                values: new object[] { new Guid("e080916c-6d0c-4d47-9012-f289c6ed7492"), 1, 0.0, new Guid("eb415d68-8d73-4135-90a4-e02cc7d66dd5"), 84.515600000000006, new Guid("cf9b6fc3-df40-4cb1-af5c-f1194f468e2c") });

            migrationBuilder.InsertData(
                table: "Purchases",
                columns: new[] { "Id", "Amount", "DiscountRate", "ItemId", "PriceAtPurchase", "ShoppingCartId" },
                values: new object[] { new Guid("9eee9ae0-3f95-4b0d-b49f-78190b771002"), 1, 12.0, new Guid("4b4bc481-6362-4a50-990f-97870cd5f61e"), 714.73612379999997, new Guid("e6227559-7ce3-4816-aad7-6d16dbf5f508") });

            migrationBuilder.InsertData(
                table: "Purchases",
                columns: new[] { "Id", "Amount", "DiscountRate", "ItemId", "PriceAtPurchase", "ShoppingCartId" },
                values: new object[] { new Guid("5f02c6b4-7c9d-41c7-acae-819976c8619b"), 1, 0.0, new Guid("ac5121c3-6215-4475-8c2c-9559dec2db4d"), 144.18700000000001, new Guid("e6227559-7ce3-4816-aad7-6d16dbf5f508") });

            migrationBuilder.InsertData(
                table: "Purchases",
                columns: new[] { "Id", "Amount", "DiscountRate", "ItemId", "PriceAtPurchase", "ShoppingCartId" },
                values: new object[] { new Guid("b3087fa3-2abd-48d6-881f-15126c40d255"), 1, 12.0, new Guid("78e0e6d9-02a8-46fa-8135-5891ac904db2"), 612.45609999999999, new Guid("e6227559-7ce3-4816-aad7-6d16dbf5f508") });

            migrationBuilder.InsertData(
                table: "Purchases",
                columns: new[] { "Id", "Amount", "DiscountRate", "ItemId", "PriceAtPurchase", "ShoppingCartId" },
                values: new object[] { new Guid("477398d5-55b7-4784-8676-84f9cde01cef"), 1, 0.0, new Guid("ac5121c3-6215-4475-8c2c-9559dec2db4d"), 144.18700000000001, new Guid("1bb3315e-ee7f-4688-acfa-ca1c5a3f980b") });

            migrationBuilder.InsertData(
                table: "Purchases",
                columns: new[] { "Id", "Amount", "DiscountRate", "ItemId", "PriceAtPurchase", "ShoppingCartId" },
                values: new object[] { new Guid("861fc8d1-a1cb-4d10-91d9-68359f159d34"), 1, 0.0, new Guid("eb415d68-8d73-4135-90a4-e02cc7d66dd5"), 84.515600000000006, new Guid("e6227559-7ce3-4816-aad7-6d16dbf5f508") });

            migrationBuilder.InsertData(
                table: "Purchases",
                columns: new[] { "Id", "Amount", "DiscountRate", "ItemId", "PriceAtPurchase", "ShoppingCartId" },
                values: new object[] { new Guid("39c03902-4f50-49b8-8c38-29c08c68a409"), 1, 0.0, new Guid("ac5121c3-6215-4475-8c2c-9559dec2db4d"), 144.18700000000001, new Guid("8ea25f16-137d-4fa7-a9a2-e7fa993e53da") });

            migrationBuilder.InsertData(
                table: "Purchases",
                columns: new[] { "Id", "Amount", "DiscountRate", "ItemId", "PriceAtPurchase", "ShoppingCartId" },
                values: new object[] { new Guid("e16a4f7e-0ebd-48dd-81c8-6b1cbc0e5a73"), 1, 0.0, new Guid("78e0e6d9-02a8-46fa-8135-5891ac904db2"), 612.45609999999999, new Guid("8ea25f16-137d-4fa7-a9a2-e7fa993e53da") });

            migrationBuilder.InsertData(
                table: "Purchases",
                columns: new[] { "Id", "Amount", "DiscountRate", "ItemId", "PriceAtPurchase", "ShoppingCartId" },
                values: new object[] { new Guid("f89f9282-ab72-4867-9064-32a2d1086f37"), 1, 0.0, new Guid("eb415d68-8d73-4135-90a4-e02cc7d66dd5"), 84.515600000000006, new Guid("8ea25f16-137d-4fa7-a9a2-e7fa993e53da") });

            migrationBuilder.InsertData(
                table: "Purchases",
                columns: new[] { "Id", "Amount", "DiscountRate", "ItemId", "PriceAtPurchase", "ShoppingCartId" },
                values: new object[] { new Guid("9c88ec30-db42-4e3d-af39-9913fc6fa8ba"), 1, 12.0, new Guid("4b4bc481-6362-4a50-990f-97870cd5f61e"), 714.73612379999997, new Guid("0735abdb-1fa2-4598-bb01-2ac4afffa251") });

            migrationBuilder.InsertData(
                table: "Purchases",
                columns: new[] { "Id", "Amount", "DiscountRate", "ItemId", "PriceAtPurchase", "ShoppingCartId" },
                values: new object[] { new Guid("07dec7b8-01c0-4d35-aa68-02fce38a5ca0"), 1, 0.0, new Guid("ac5121c3-6215-4475-8c2c-9559dec2db4d"), 144.18700000000001, new Guid("0735abdb-1fa2-4598-bb01-2ac4afffa251") });

            migrationBuilder.InsertData(
                table: "Purchases",
                columns: new[] { "Id", "Amount", "DiscountRate", "ItemId", "PriceAtPurchase", "ShoppingCartId" },
                values: new object[] { new Guid("f2317c36-5f7a-464e-a110-e663abe51a03"), 1, 0.0, new Guid("78e0e6d9-02a8-46fa-8135-5891ac904db2"), 612.45609999999999, new Guid("0735abdb-1fa2-4598-bb01-2ac4afffa251") });

            migrationBuilder.InsertData(
                table: "Purchases",
                columns: new[] { "Id", "Amount", "DiscountRate", "ItemId", "PriceAtPurchase", "ShoppingCartId" },
                values: new object[] { new Guid("674e6300-3731-461d-b0ca-bae324f6a59a"), 1, 0.0, new Guid("eb415d68-8d73-4135-90a4-e02cc7d66dd5"), 84.515600000000006, new Guid("0735abdb-1fa2-4598-bb01-2ac4afffa251") });

            migrationBuilder.InsertData(
                table: "Purchases",
                columns: new[] { "Id", "Amount", "DiscountRate", "ItemId", "PriceAtPurchase", "ShoppingCartId" },
                values: new object[] { new Guid("da3ba1d7-c379-4bd6-b34b-e3482a6863f0"), 1, 12.0, new Guid("4b4bc481-6362-4a50-990f-97870cd5f61e"), 714.73612379999997, new Guid("7ea669b1-c896-472a-b3ae-441ab6d53012") });

            migrationBuilder.InsertData(
                table: "Purchases",
                columns: new[] { "Id", "Amount", "DiscountRate", "ItemId", "PriceAtPurchase", "ShoppingCartId" },
                values: new object[] { new Guid("dd908313-1759-45ab-9f35-15c3b9eac4f4"), 1, 0.0, new Guid("ac5121c3-6215-4475-8c2c-9559dec2db4d"), 144.18700000000001, new Guid("7ea669b1-c896-472a-b3ae-441ab6d53012") });

            migrationBuilder.InsertData(
                table: "Purchases",
                columns: new[] { "Id", "Amount", "DiscountRate", "ItemId", "PriceAtPurchase", "ShoppingCartId" },
                values: new object[] { new Guid("f3d468e4-b8e7-4dee-b8cb-2eb5367dfdd2"), 1, 12.0, new Guid("4b4bc481-6362-4a50-990f-97870cd5f61e"), 714.73612379999997, new Guid("8ea25f16-137d-4fa7-a9a2-e7fa993e53da") });

            migrationBuilder.InsertData(
                table: "Purchases",
                columns: new[] { "Id", "Amount", "DiscountRate", "ItemId", "PriceAtPurchase", "ShoppingCartId" },
                values: new object[] { new Guid("4a8d53fc-4c09-4dd8-941a-5eeafed2e1bc"), 1, 12.0, new Guid("4b4bc481-6362-4a50-990f-97870cd5f61e"), 714.73612379999997, new Guid("1bb3315e-ee7f-4688-acfa-ca1c5a3f980b") });

            migrationBuilder.InsertData(
                table: "Purchases",
                columns: new[] { "Id", "Amount", "DiscountRate", "ItemId", "PriceAtPurchase", "ShoppingCartId" },
                values: new object[] { new Guid("d1de98fb-5dcc-4c09-b0e7-b658e31c461e"), 1, 0.0, new Guid("1e3994f6-3810-4f38-ad31-6779a169b415"), 84.515600000000006, new Guid("cb20886a-380d-4368-a419-a0c4990ed2d6") });

            migrationBuilder.InsertData(
                table: "Purchases",
                columns: new[] { "Id", "Amount", "DiscountRate", "ItemId", "PriceAtPurchase", "ShoppingCartId" },
                values: new object[] { new Guid("1a1a41b7-0d2b-4f98-911f-d69e9e8f1e5d"), 1, 12.0, new Guid("78e0e6d9-02a8-46fa-8135-5891ac904db2"), 612.45609999999999, new Guid("cb20886a-380d-4368-a419-a0c4990ed2d6") });

            migrationBuilder.InsertData(
                table: "Purchases",
                columns: new[] { "Id", "Amount", "DiscountRate", "ItemId", "PriceAtPurchase", "ShoppingCartId" },
                values: new object[] { new Guid("104d70e3-2ff0-4c0c-8c39-10dd140f7f02"), 1, 0.0, new Guid("ac5121c3-6215-4475-8c2c-9559dec2db4d"), 144.18700000000001, new Guid("6959a3f5-fe27-43ce-8728-e987f9dde300") });

            migrationBuilder.InsertData(
                table: "Purchases",
                columns: new[] { "Id", "Amount", "DiscountRate", "ItemId", "PriceAtPurchase", "ShoppingCartId" },
                values: new object[] { new Guid("2a5c1d51-0e39-4dff-b38b-73a8350aaa31"), 1, 12.0, new Guid("78e0e6d9-02a8-46fa-8135-5891ac904db2"), 612.45609999999999, new Guid("6959a3f5-fe27-43ce-8728-e987f9dde300") });

            migrationBuilder.InsertData(
                table: "Purchases",
                columns: new[] { "Id", "Amount", "DiscountRate", "ItemId", "PriceAtPurchase", "ShoppingCartId" },
                values: new object[] { new Guid("5d1e4991-9821-40f8-9979-b2d2b2424425"), 1, 0.0, new Guid("eb415d68-8d73-4135-90a4-e02cc7d66dd5"), 84.515600000000006, new Guid("6959a3f5-fe27-43ce-8728-e987f9dde300") });

            migrationBuilder.InsertData(
                table: "Purchases",
                columns: new[] { "Id", "Amount", "DiscountRate", "ItemId", "PriceAtPurchase", "ShoppingCartId" },
                values: new object[] { new Guid("742cea3d-26d7-4194-8d67-9f2a7b6a9b28"), 1, 12.0, new Guid("75ccf681-e4b9-4772-97eb-39c61d44ed45"), 407.88, new Guid("d1c2d163-5358-49e1-84c1-9cda5faa2852") });

            migrationBuilder.InsertData(
                table: "Purchases",
                columns: new[] { "Id", "Amount", "DiscountRate", "ItemId", "PriceAtPurchase", "ShoppingCartId" },
                values: new object[] { new Guid("24c98e31-382a-4739-a31c-c416d4cf78c7"), 1, 0.0, new Guid("ac5121c3-6215-4475-8c2c-9559dec2db4d"), 144.18700000000001, new Guid("d1c2d163-5358-49e1-84c1-9cda5faa2852") });

            migrationBuilder.InsertData(
                table: "Purchases",
                columns: new[] { "Id", "Amount", "DiscountRate", "ItemId", "PriceAtPurchase", "ShoppingCartId" },
                values: new object[] { new Guid("ba516a6b-96f9-4f7b-8d16-5c8a366977f5"), 1, 12.0, new Guid("78e0e6d9-02a8-46fa-8135-5891ac904db2"), 612.45609999999999, new Guid("d1c2d163-5358-49e1-84c1-9cda5faa2852") });

            migrationBuilder.InsertData(
                table: "Purchases",
                columns: new[] { "Id", "Amount", "DiscountRate", "ItemId", "PriceAtPurchase", "ShoppingCartId" },
                values: new object[] { new Guid("f41cda4d-8eb2-4613-a3b8-b1e8e9d0c6dc"), 1, 0.0, new Guid("eb415d68-8d73-4135-90a4-e02cc7d66dd5"), 84.515600000000006, new Guid("d1c2d163-5358-49e1-84c1-9cda5faa2852") });

            migrationBuilder.InsertData(
                table: "Purchases",
                columns: new[] { "Id", "Amount", "DiscountRate", "ItemId", "PriceAtPurchase", "ShoppingCartId" },
                values: new object[] { new Guid("4db0e76b-94e5-46d4-bbc8-42f8b61d446d"), 1, 12.0, new Guid("75ccf681-e4b9-4772-97eb-39c61d44ed45"), 407.88, new Guid("e4c52648-bd1f-4464-991b-7d0083d2c5a1") });

            migrationBuilder.InsertData(
                table: "Purchases",
                columns: new[] { "Id", "Amount", "DiscountRate", "ItemId", "PriceAtPurchase", "ShoppingCartId" },
                values: new object[] { new Guid("14342f78-40d7-45b9-aafe-cc30fbd1b07a"), 1, 0.0, new Guid("ac5121c3-6215-4475-8c2c-9559dec2db4d"), 144.18700000000001, new Guid("e4c52648-bd1f-4464-991b-7d0083d2c5a1") });

            migrationBuilder.InsertData(
                table: "Purchases",
                columns: new[] { "Id", "Amount", "DiscountRate", "ItemId", "PriceAtPurchase", "ShoppingCartId" },
                values: new object[] { new Guid("2943ceba-ba6f-4d1d-b22b-00b84e541734"), 1, 12.0, new Guid("78e0e6d9-02a8-46fa-8135-5891ac904db2"), 612.45609999999999, new Guid("e4c52648-bd1f-4464-991b-7d0083d2c5a1") });

            migrationBuilder.InsertData(
                table: "Purchases",
                columns: new[] { "Id", "Amount", "DiscountRate", "ItemId", "PriceAtPurchase", "ShoppingCartId" },
                values: new object[] { new Guid("a56f5f09-c1c1-47ba-ba53-b313d5e0969c"), 1, 0.0, new Guid("eb415d68-8d73-4135-90a4-e02cc7d66dd5"), 84.515600000000006, new Guid("e4c52648-bd1f-4464-991b-7d0083d2c5a1") });

            migrationBuilder.InsertData(
                table: "Purchases",
                columns: new[] { "Id", "Amount", "DiscountRate", "ItemId", "PriceAtPurchase", "ShoppingCartId" },
                values: new object[] { new Guid("536e69a3-8ab3-4f45-b65c-0ef76cbe132e"), 1, 12.0, new Guid("75ccf681-e4b9-4772-97eb-39c61d44ed45"), 407.88, new Guid("6053c15c-7316-4405-9eaf-43100e18f514") });

            migrationBuilder.InsertData(
                table: "Purchases",
                columns: new[] { "Id", "Amount", "DiscountRate", "ItemId", "PriceAtPurchase", "ShoppingCartId" },
                values: new object[] { new Guid("64c854c0-2161-4375-acbc-8feec788a9f0"), 1, 0.0, new Guid("ac5121c3-6215-4475-8c2c-9559dec2db4d"), 144.18700000000001, new Guid("6053c15c-7316-4405-9eaf-43100e18f514") });

            migrationBuilder.InsertData(
                table: "Purchases",
                columns: new[] { "Id", "Amount", "DiscountRate", "ItemId", "PriceAtPurchase", "ShoppingCartId" },
                values: new object[] { new Guid("e5363cda-54cc-4afe-91bb-9e633fbb22c1"), 1, 12.0, new Guid("78e0e6d9-02a8-46fa-8135-5891ac904db2"), 612.45609999999999, new Guid("6053c15c-7316-4405-9eaf-43100e18f514") });

            migrationBuilder.InsertData(
                table: "Purchases",
                columns: new[] { "Id", "Amount", "DiscountRate", "ItemId", "PriceAtPurchase", "ShoppingCartId" },
                values: new object[] { new Guid("e051782e-bb37-4281-b2b0-d87a1aa8d774"), 1, 0.0, new Guid("eb415d68-8d73-4135-90a4-e02cc7d66dd5"), 84.515600000000006, new Guid("6053c15c-7316-4405-9eaf-43100e18f514") });

            migrationBuilder.InsertData(
                table: "Purchases",
                columns: new[] { "Id", "Amount", "DiscountRate", "ItemId", "PriceAtPurchase", "ShoppingCartId" },
                values: new object[] { new Guid("55abfc63-936d-49fe-a5a5-ccaf14647620"), 1, 12.0, new Guid("4b4bc481-6362-4a50-990f-97870cd5f61e"), 714.73612379999997, new Guid("c1b9e69f-3b27-4e5b-bb78-a6c1c83fea11") });

            migrationBuilder.InsertData(
                table: "Purchases",
                columns: new[] { "Id", "Amount", "DiscountRate", "ItemId", "PriceAtPurchase", "ShoppingCartId" },
                values: new object[] { new Guid("a2683ecf-aa6d-482a-96de-526d6ac66cac"), 1, 0.0, new Guid("ac5121c3-6215-4475-8c2c-9559dec2db4d"), 144.18700000000001, new Guid("c1b9e69f-3b27-4e5b-bb78-a6c1c83fea11") });

            migrationBuilder.InsertData(
                table: "Purchases",
                columns: new[] { "Id", "Amount", "DiscountRate", "ItemId", "PriceAtPurchase", "ShoppingCartId" },
                values: new object[] { new Guid("cf7f87be-10de-4ad9-9331-b3c2590c8946"), 1, 12.0, new Guid("78e0e6d9-02a8-46fa-8135-5891ac904db2"), 612.45609999999999, new Guid("c1b9e69f-3b27-4e5b-bb78-a6c1c83fea11") });

            migrationBuilder.InsertData(
                table: "Purchases",
                columns: new[] { "Id", "Amount", "DiscountRate", "ItemId", "PriceAtPurchase", "ShoppingCartId" },
                values: new object[] { new Guid("f1aecddd-83e1-4a1d-8e1c-1361d4853e38"), 1, 0.0, new Guid("eb415d68-8d73-4135-90a4-e02cc7d66dd5"), 84.515600000000006, new Guid("c1b9e69f-3b27-4e5b-bb78-a6c1c83fea11") });

            migrationBuilder.InsertData(
                table: "Purchases",
                columns: new[] { "Id", "Amount", "DiscountRate", "ItemId", "PriceAtPurchase", "ShoppingCartId" },
                values: new object[] { new Guid("700b098c-9852-4835-97a6-d021a0cbc5dc"), 1, 12.0, new Guid("4b4bc481-6362-4a50-990f-97870cd5f61e"), 714.73612379999997, new Guid("cb20886a-380d-4368-a419-a0c4990ed2d6") });

            migrationBuilder.InsertData(
                table: "Purchases",
                columns: new[] { "Id", "Amount", "DiscountRate", "ItemId", "PriceAtPurchase", "ShoppingCartId" },
                values: new object[] { new Guid("a09a5fbe-3adb-4be3-b7cd-da2e22127c4e"), 1, 12.0, new Guid("4ca15527-db80-4337-8b22-7309c02fe08f"), 173.25299999999999, new Guid("cb20886a-380d-4368-a419-a0c4990ed2d6") });

            migrationBuilder.InsertData(
                table: "Purchases",
                columns: new[] { "Id", "Amount", "DiscountRate", "ItemId", "PriceAtPurchase", "ShoppingCartId" },
                values: new object[] { new Guid("72fadb97-c054-4b23-a702-5cbdb3463247"), 1, 50.0, new Guid("78e0e6d9-02a8-46fa-8135-5891ac904db2"), 612.45609999999999, new Guid("7ea669b1-c896-472a-b3ae-441ab6d53012") });

            migrationBuilder.InsertData(
                table: "Purchases",
                columns: new[] { "Id", "Amount", "DiscountRate", "ItemId", "PriceAtPurchase", "ShoppingCartId" },
                values: new object[] { new Guid("600902e5-4104-40d6-af7e-9338482b3ad2"), 1, 0.0, new Guid("eb415d68-8d73-4135-90a4-e02cc7d66dd5"), 84.515600000000006, new Guid("7ea669b1-c896-472a-b3ae-441ab6d53012") });

            migrationBuilder.CreateIndex(
                name: "IX_Purchases_ItemId",
                table: "Purchases",
                column: "ItemId");

            migrationBuilder.CreateIndex(
                name: "IX_Purchases_ShoppingCartId",
                table: "Purchases",
                column: "ShoppingCartId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Purchases");

            migrationBuilder.DropTable(
                name: "ShoppingCarts");

            migrationBuilder.DropTable(
                name: "ShoppingItem");
        }
    }
}
