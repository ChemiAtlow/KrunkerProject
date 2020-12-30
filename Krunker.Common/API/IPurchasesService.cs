using Krunker.Common.Models;
using Krunker.Common.Exceptions;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Krunker.Common.API
{
    public interface IPurchasesService
    {
        /// <summary>
        /// Generate a new shopping cart.
        /// </summary>
        /// <returns>The newely created cart. enjoy your purchase!</returns>
        Task<ShoppingCart> GenerateNewCartAsync();

        /// <summary>
        /// Get a cart by its ID
        /// </summary>
        /// <param name="id">ID to search for</param>
        /// <returns>Item with the given ID.</returns>
        /// <exception cref="KeyNotFoundException">Thrown if the service dosent contain an item with the given ID</exception>
        Task<ShoppingCart> GetCartByIdAsync(Guid id);

        /// <summary>
        /// Add an item to the shopping cart.
        /// </summary>
        /// <param name="itemId">Item to add.</param>
        /// <param name="shoppingCartId">Shopping cart to add item to.</param>
        /// <exception cref="KeyNotFoundException">Thrown if the shopping cart or the item is not found.</exception>
        /// <exception cref="ShoppingCartClosedException">The requested shopping cart is already closed.</exception>
        /// <exception cref="ItemSoldOutException">The item is not available in shop.</exception>
        Task<Purchase> AddItemToCartAsync(Guid itemId, Guid shoppingCartId, int amount);

        /// <summary>
        /// Remove a purchase from the shopping cart.
        /// </summary>
        /// <param name="purchaseId">Id of purchase to remove.</param>
        /// <param name="shoppingCartId">Shopping cart to remove item from.</param>
        /// <exception cref="ShoppingCartClosedException">The requested shopping cart is already closed.</exception>
        /// <exception cref="ItemNotInCartException">The item is not in the cart.</exception>
        Task<Purchase> RemovePurchaseFromCartAsync(Guid purchaseId, Guid shoppingCartId);

        /// <summary>
        /// Purchase all items in the cart.
        /// </summary>
        /// <param name="shoppingCartId">Id of cart to purchase</param>
        /// <exception cref="KeyNotFoundException">Thrown if the shopping cart is not found.</exception>
        /// <exception cref="ShoppingCartClosedException">The requested shopping cart is already closed.</exception>
        Task PurchaseCartAsync(Guid shoppingCartId);

        /// <summary>
        /// Get all completed purchases.
        /// </summary>
        /// <returns>List of all completed purchases.</returns>
        IEnumerable<ShoppingCart> GetAllCompletedPurchases();
    }
}
