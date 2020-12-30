using Krunker.Common.API;
using Krunker.Common.Exceptions;
using Krunker.Common.Interfaces;
using Krunker.Common.Models;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Krunker.BL.Services
{
    public class PurchaseService : IPurchasesService
    {
        private readonly IProductsService productsService;
        private readonly IRepository<Purchase> purchaseRepository;
        private readonly IRepository<ShoppingCart> shoppingCartRepository;
        private readonly ILogger<IPurchasesService> logger;

        public PurchaseService(
            IProductsService productsService,
            IRepository<Purchase> purchaseRepository,
            IRepository<ShoppingCart> shoppingCartRepository,
            ILogger<IPurchasesService> logger)
        {
            this.productsService = productsService;
            this.purchaseRepository = purchaseRepository;
            this.shoppingCartRepository = shoppingCartRepository;
            this.logger = logger;
        }


        public async Task<ShoppingCart> GetCartByIdAsync(Guid id)
        {
            return await shoppingCartRepository.GetItemByIdAsync(id);
        }

        public async Task<ShoppingCart> GenerateNewCartAsync()
        {
            try
            {
                return await shoppingCartRepository.AddAsync(new());
            }
            catch (Exception e)
            {
                logger.LogError(e, "Error generating new cart!");
                throw;
            }
        }

        public async Task<Purchase> AddItemToCartAsync(Guid itemId, Guid shoppingCartId, int amount)
        {
            IShoppingItem item = await productsService.GetItemByIDAsync(itemId);
            ShoppingCart cart = await GetCartByIdAsync(shoppingCartId);
            if (item.CurrentAmount == 0)
                throw new ItemSoldOutException($"Attempted to purchase: {item.Name}. this item is sold out!");
            if (cart.PurchaseComplete)
                throw new ShoppingCartClosedException("Attempted to add items to a closed cart!");
            item.Use(amount);
            Purchase purchase = cart.Purchases.FirstOrDefault(p => p.ItemId == itemId);
            bool isNewPurchase = false;
            if (purchase is not null)
            {
                purchase.Amount += amount;
            } else
            {
                purchase = new() { Amount = amount, ItemId = itemId, ShoppingCartId = shoppingCartId, PriceAtPurchase = item.CalculatedPrice, DiscountRate = item.Discount };
                isNewPurchase = true;
            }
            cart.TotalPrice = cart.Purchases.Sum(p => p.PriceAtPurchase * p.Amount);
            await productsService.UpdateProductAsync(item.Id, item);
            await shoppingCartRepository.UpdateAsync(cart);
            return isNewPurchase ? await purchaseRepository.AddAsync(purchase) : await purchaseRepository.UpdateAsync(purchase);
        }

        public async Task<Purchase> RemovePurchaseFromCartAsync(Guid purchaseId, Guid shoppingCartId)
        {
            Purchase purchase = purchaseRepository.GetAll().FirstOrDefault(p => p.Id == purchaseId && p.ShoppingCartId == shoppingCartId);
            if (purchase is null)
                throw new ItemNotInCartException("The item requested was not found in the cart");
            if (purchase.ShoppingCart.PurchaseComplete)
                throw new ShoppingCartClosedException("Attempted to remove items from a closed cart!");
            purchase.Item.Add(purchase.Amount);
            purchase.ShoppingCart.TotalPrice -= purchase.PriceAtPurchase * purchase.Amount;
            await purchaseRepository.RemoveAsync(purchase);
            await shoppingCartRepository.UpdateAsync(purchase.ShoppingCart);
            await productsService.UpdateProductAsync(purchase.Item.Id, purchase.Item);
            return purchase;
        }

        public IEnumerable<ShoppingCart> GetAllCompletedPurchases()
        {
            return shoppingCartRepository.GetAll().Where(sc => sc.PurchaseComplete);
        }

        public async Task PurchaseCartAsync(Guid shoppingCartId)
        {
            //Payment ETC
            ShoppingCart cart = await shoppingCartRepository.GetItemByIdAsync(shoppingCartId);
            if (cart.PurchaseComplete) throw new ShoppingCartClosedException("Can't re purchase a cart!");
            cart.PurchaseComplete = true;
            cart.PurchaseTime = DateTime.Now;
            await shoppingCartRepository.UpdateAsync(cart);
        }
    }
}
