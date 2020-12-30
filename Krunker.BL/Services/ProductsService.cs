using Krunker.Common.API;
using Krunker.Common.Exceptions;
using Krunker.Common.Interfaces;
using Krunker.Common.Models;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Web;

namespace Krunker.BL.Services
{
    public class ProductsService : IProductsService
    {
        private readonly IRepository<ShoppingItem> repository;
        private readonly IWebHostEnvironment webHostEnvironment;
        private readonly ILogger<IProductsService> logger;

        public ProductsService(
            IRepository<ShoppingItem> repository,
            IWebHostEnvironment webHostEnvironment,
            ILogger<IProductsService> logger)
        {
            this.repository = repository;
            this.webHostEnvironment = webHostEnvironment;
            this.logger = logger;
        }


        public IEnumerable<IShoppingItem> GetAll()
        {
            try
            {
                return repository.GetAll().Where(si => !si.Archived);
            }
            catch (Exception e)
            {
                logger.LogWarning(e, "Error getting back items.");
                return Enumerable.Empty<IShoppingItem>();
            };
        }

        public async Task<IShoppingItem> GetItemByIDAsync(Guid itemID)
        {
            IShoppingItem item = await repository.GetItemByIdAsync(itemID);
            if (item is not null) return item;
            throw new KeyNotFoundException("Could not find an item with the given ID!");
        }

        public async Task<IShoppingItem> AddProductAsync(IShoppingItem item)
        {
            if (item is null) throw new ArgumentNullException(nameof(item), "Item can't be null");
            try
            {
                if (item.Image is null) throw new ItemCreatedWithoutImageException("Can't create item without image!");
                string fileName = UploadFile(item.Image);
                item.UriImg = fileName;
                return await repository.AddAsync((ShoppingItem)item);
            }
            catch (ItemCreatedWithoutImageException e)
            {
                logger.LogInformation(e, "Item creation declined - no image.");
                throw;
            }
            catch (DbUpdateException e)
            {
                logger.LogWarning(e, "Item creation error - db update issue.");
                throw;
            }
            catch (Exception e)
            {
                logger.LogError(e, "Item creation error - db unknown issue.");
                throw;
            }
        }

        public async Task<IShoppingItem> RemoveProductAsync(Guid id)
        {
            try
            {
                IShoppingItem item = await GetItemByIDAsync(id);
                return await repository.RemoveAsync((ShoppingItem)item);
            }
            catch (DbUpdateException e)
            {
                logger.LogWarning(e, "Item removing error - db update issue.");
                throw;
            }
            catch (Exception e)
            {
                logger.LogError(e, "Item removing error - db unknown issue.");
                throw;
            }
        }

        public async Task<IShoppingItem> UpdateProductAsync(Guid id, IShoppingItem item)
        {
            if (item is null)
                throw new ArgumentNullException(nameof(item), "Item can't be null");
            try
            {
                if (item.Image is not null)
                {
                    string fileName = UploadFile(item.Image);
                    item.UriImg = fileName;
                }
                item.Id = id;
                return await repository.UpdateAsync((ShoppingItem)item);
            }
            catch (DbUpdateException e)
            {
                logger.LogWarning(e, "Item updating error - db update issue.");
                throw;
            }
            catch (Exception e)
            {
                logger.LogError(e, "Item updating error - db unknown issue.");
                throw;
            }
            //return item switch
            //{
            //    BackItem i => await backItemRepository.UpdateAsync(i),
            //    HeadItem i => await headItemRepository.UpdateAsync(i),
            //    PrimaryWeapon i => await primaryWeaponRepository.UpdateAsync(i),
            //    SecondaryWeapon i => await secondaryWeaponRepository.UpdateAsync(i),
            //    _ => LogErrorAndReturnNeeded<object>($"Attempted to update an unhandeld type: {item.GetType().Name}")
            //};
        }

        private string UploadFile(IFormFile file)
        {
            string uniqueFileName = null;

            if (file is not null)
            {
                string uploadsFolder = Path.Combine(webHostEnvironment.WebRootPath, "images");
                uniqueFileName = Guid.NewGuid().ToString() + "_" + HttpUtility.HtmlEncode(file.FileName);
                string filePath = Path.Combine(uploadsFolder, uniqueFileName);
                using FileStream fileStream = new FileStream(filePath, FileMode.Create);
                file.CopyTo(fileStream);
            }
            return uniqueFileName;
        }
    }
}
