using Krunker.Common.API;
using Krunker.Common.DTOs;
using Krunker.Common.Exceptions;
using Krunker.Common.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Krunker.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CartController : ControllerBase
    {
        private readonly IPurchasesService purchasesService;

        public CartController(IPurchasesService purchasesService)
        {
            this.purchasesService = purchasesService;
        }

        // GET api/<CartController>
        [HttpGet]
        public async Task<ActionResult<ShoppingCartDTO>> Get()
        {
            try
            {
                ShoppingCart cart = await purchasesService.GenerateNewCartAsync();
                ShoppingCartDTO dtoCart = ShoppingCartDTO.FromDbModel(cart);
                return Ok(dtoCart);
            }
            catch (Exception e)
            {
                return Problem(e.Message, statusCode: StatusCodes.Status500InternalServerError);
            }
        }
        // GET api/<CartController>/5
        [HttpGet("{id:Guid}")]
        public async Task<ActionResult<ShoppingCartDTO>> Get(Guid id)
        {
            try
            {
                ShoppingCart cart = await purchasesService.GetCartByIdAsync(id);
                ShoppingCartDTO dtoCart = ShoppingCartDTO.FromDbModel(cart);
                return Ok(dtoCart);
            }
            catch (KeyNotFoundException e)
            {
                return NotFound(e.Message);
            }
            catch (Exception e)
            {
                return Problem(e.Message, statusCode: StatusCodes.Status500InternalServerError);
            }
        }

        // PUT api/<CartController>/5
        [HttpPut("{cartId:Guid}")]
        public async Task<ActionResult<PurchaseDTO>> Put(Guid cartId, [FromBody] UpdateItemRequestDTO request)
        {
            try
            {
                Purchase purchase = await purchasesService.AddItemToCartAsync(request.ItemId, cartId, request.Amount);
                PurchaseDTO purchaseDTO = PurchaseDTO.FromDbModel(purchase);
                return Ok(purchaseDTO);
            }
            catch(KeyNotFoundException e)
            {
                return NotFound(e.Message);
            }
            catch (Exception e)
            {
                if (e is ShoppingCartClosedException || e is ItemSoldOutException)
                   return BadRequest(e.Message);
                return Problem(e.Message, statusCode: StatusCodes.Status500InternalServerError);
            } 
        }

        // DELETE api/<CartController>/5
        [HttpDelete("{cartId:Guid}/{purchaseId:Guid}")]
        public async Task<ActionResult<PurchaseDTO>> Delete(Guid cartId, Guid purchaseId)
        {
            try
            {
                Purchase purchase = await purchasesService.RemovePurchaseFromCartAsync(purchaseId, cartId);
                PurchaseDTO purchaseDTO = PurchaseDTO.FromDbModel(purchase);
                return Ok(purchaseDTO);
            }
            catch (Exception e)
            {
                if (e is ShoppingCartClosedException || e is ItemNotInCartException)
                    return BadRequest(e.Message);
                return Problem(e.Message, statusCode: StatusCodes.Status500InternalServerError);
            }
        }
    }
}
