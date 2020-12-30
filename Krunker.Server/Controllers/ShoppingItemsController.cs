using Krunker.Common.API;
using Krunker.Common.DTOs;
using Krunker.Common.Exceptions;
using Krunker.Common.Interfaces;
using Krunker.Common.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Krunker.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ShoppingItemsController : ControllerBase
    {
        private readonly IProductsService productsService;
        private readonly ILogger<ShoppingItemsController> logger;

        public ShoppingItemsController(IProductsService productsService, ILogger<ShoppingItemsController> logger)
        {
            this.productsService = productsService;
            this.logger = logger;
        }

        // GET: api/<ShoppingItemsController>
        [HttpGet]
        public ActionResult<IEnumerable<ShoppingItemDTO>> Get()
        {
            try
            {
                var items = productsService.GetAll().Select(i => ShoppingItemDTO.FromDbModel(i));
                return Ok(items);
            }
            catch (Exception e)
            {
                logger.LogError(e, "Issue getting items!");
                return Problem(e.Message, statusCode: StatusCodes.Status500InternalServerError);
            }
        }

        // GET api/<ShoppingItemsController>/5
        [HttpGet("{id:Guid}")]
        public async Task<ActionResult<ShoppingItemDTO>> Get(Guid id)
        {
            try
            {
                IShoppingItem item = await productsService.GetItemByIDAsync(id);
                return Ok(ShoppingItemDTO.FromDbModel(item));
            }
            catch (KeyNotFoundException e)
            {
                return BadRequest(e.Message);
            }
            catch (Exception e)
            {
                return Problem(e.Message, statusCode: StatusCodes.Status500InternalServerError);
            }
        }

        // POST api/<ShoppingItemsController>
        [HttpPost]
        public async Task<ActionResult<ShoppingItemDTO>> Post([FromForm] ShoppingItem shoppingItem)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);
            try
            {
                return ShoppingItemDTO.FromDbModel(await productsService.AddProductAsync(shoppingItem));
            }
            catch (ItemCreatedWithoutImageException e)
            {
                return BadRequest(e.Message);
            }
            catch (Exception e)
            {
                return Problem(e.Message, statusCode: StatusCodes.Status500InternalServerError);
            }
        }
        // PUT api/<ShoppingItemsController>/5
        [HttpPut("{id:Guid}")]
        public async Task<ActionResult<ShoppingItemDTO>> Put(Guid id, [FromForm] ShoppingItem shoppingItem)
        {

            if (!ModelState.IsValid) return BadRequest(ModelState);
            try
            {
                return ShoppingItemDTO.FromDbModel(await productsService.UpdateProductAsync(id, shoppingItem));
            }
            catch (Exception e)
            {
                return Problem(e.Message, statusCode: StatusCodes.Status500InternalServerError);
            }
        }

        // DELETE api/<ShoppingItemsController>/5
        [HttpDelete("{id:Guid}")]
        public async Task<ActionResult<ShoppingItemDTO>> Delete(Guid id)
        {
            try
            {
                return ShoppingItemDTO.FromDbModel(await productsService.RemoveProductAsync(id));
            }
            catch (Exception e)
            {
                return Problem(e.Message, statusCode: StatusCodes.Status500InternalServerError);
            }
        }
    }
}
