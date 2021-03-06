using Application.Products;
using Domain;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace API.Controllers
{
    public class ProductController : BaseApiController
    {

        [HttpGet]
        public async Task<ActionResult<List<Product>>> GetProducts()
        {
            return await Mediator.Send(new List.Query());
        }
        [HttpGet("{id}")] //product/id
        public async Task<ActionResult<Product>> GetProductById(Guid id)
        {
            return await Mediator.Send(new Details.Query { ID = id });
        }
        [HttpPost]
        public async Task<IActionResult> CreateProduct(Product product)
        {
            return Ok(await Mediator.Send(new Create.Command { Product = product }));
        }
        [HttpPut("{id}")]
        public async Task<IActionResult> EditProduct(Guid id,Product product)
        {
            product.Id = id;
            return Ok(await Mediator.Send(new Edit.Command { Product = product }));
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteProduct(Guid id)
        {
            return Ok(await Mediator.Send(new Delete.Command { Id = id }));
        }
    }
}
