using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Stores.Services;
using StoresChain.Models;

namespace StoresChain.Controllers
{
    [Route("api/store")]
    [ApiController]
    public class StoreController : Controller
    {
        StoreService storeService;
        public StoreController()
        {
            storeService = new StoreService();
        }

        [HttpGet("list")]
        public IEnumerable<Store> GetStoresList()
        {
            return storeService.Stores.GetAll();
        }

        [HttpGet("prodlist/{storeId}")]
        public IEnumerable<Product> GetProductsList(int storeId)
        {
            return storeService.Products.GetByStoreId(storeId);
        }

        [HttpPost("removeproduct")]
        public ValidityResponse RemoveProduct([FromBody] Product product)
        {
            storeService.Products.Delete(product.ProductId);
            storeService.Save();
            return new ValidityResponse() { IsSuccessful = true, Message = "OK" };
        }

        [HttpPost("createproduct")]
        public ValidityResponse CreateProduct([FromBody] Product product)
        {
            storeService.Products.Create(product);
            storeService.Save();
            return new ValidityResponse() { IsSuccessful = true, Message = "OK" };
        }

        [HttpPost("updateproduct")]
        public ValidityResponse UpdateProduct([FromBody] Product product)
        {
            storeService.Products.Update(product);
            storeService.Save();
            return new ValidityResponse() { IsSuccessful = true, Message = "OK" };
        }

        protected override void Dispose(bool disposing)
        {
            storeService.Dispose();
            base.Dispose(disposing);
        }
    }
}
