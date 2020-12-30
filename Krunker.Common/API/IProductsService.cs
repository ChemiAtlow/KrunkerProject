using Krunker.Common.Interfaces;
using Krunker.Common.Exceptions;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Krunker.Common.API
{
    public interface IProductsService
    {
        /// <summary>
        /// Get all items unsorted.
        /// </summary>
        /// <returns>List of all abstract items.</returns>
        IEnumerable<IShoppingItem> GetAll();

        /// <summary>
        /// Get an item by it's ID
        /// </summary>
        /// <param name="itemID">ID to search by</param>
        /// <returns>Item with the given ID.</returns>
        /// <exception cref="KeyNotFoundException">Thrown if the service dosent contain an item with the given ID</exception>
        Task<IShoppingItem> GetItemByIDAsync(Guid itemID);

        /// <summary>
        /// Add an item to the service.
        /// </summary>
        /// <param name="item">Item to add.</param>
        /// <exception cref="ItemCreatedWithoutImageException">Thrown if item was generated without image.</exception>
        /// <exception cref="ArgumentNullException">Thrown if the item is null.</exception>
        Task<IShoppingItem> AddProductAsync(IShoppingItem item);

        /// <summary>
        /// Remove an Item from the service.
        /// </summary>
        /// <param name="id">id of item to remove</param>
        /// <exception cref="KeyNotFoundException">Thrown if the service dosent contain an item with the given ID</exception>
        Task<IShoppingItem> RemoveProductAsync(Guid id);

        /// <summary>
        /// Update an item of the service. update the item with given id.
        /// </summary>
        /// <param name="id">Id of item to update.</param>
        /// <param name="item">Item to update.</param>
        /// <exception cref="ArgumentNullException">Thrown if no item conatins given item's ID, or item with given id is not of same type.</exception>
        /// <exception cref="KeyNotFoundException">Thrown if the service dosent contain an item with the given ID</exception>
        Task<IShoppingItem> UpdateProductAsync(Guid id, IShoppingItem item);
    }
}
