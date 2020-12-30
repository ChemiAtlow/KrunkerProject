using Krunker.Common.API;
using Krunker.Common.DTOs;
using Krunker.Common.Exceptions;
using Krunker.Common.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Krunker.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PurchaseController : ControllerBase
    {
        private readonly IPurchasesService purchasesService;

        public PurchaseController(IPurchasesService purchasesService)
        {
            this.purchasesService = purchasesService;
        }


        // GET: api/<PurchaseController>
        [HttpGet]
        public ActionResult<IEnumerable<ShoppingCartDTO>> Get()
        {
            try
            {
                IEnumerable<ShoppingCart> carts = purchasesService.GetAllCompletedPurchases();
                IEnumerable<ShoppingCartDTO> cartDTOs = carts.Select(c => ShoppingCartDTO.FromDbModel(c));
                return Ok(cartDTOs);
            }
            catch (Exception e)
            {
                return Problem(e.Message, statusCode: StatusCodes.Status500InternalServerError);
            }
        }

        // POST api/<PurchaseController>/5
        [HttpPost("{id}")]
        public async Task<ActionResult> Post(Guid id)
        {
            try
            {
                await purchasesService.PurchaseCartAsync(id);
                return Ok();
            }
            catch (KeyNotFoundException e)
            {
                return NotFound(e.Message);
            }
            catch (ShoppingCartClosedException e)
            {
                return BadRequest(e.Message);
            }
            catch (Exception e)
            {
                return Problem(e.Message, statusCode: StatusCodes.Status500InternalServerError);
            }
        }
    }
}
