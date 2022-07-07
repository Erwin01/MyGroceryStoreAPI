using Microsoft.AspNetCore.Mvc;
using MyGroceryStoreAPI.Models;
using MyGroceryStoreAPI.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyGroceryStoreAPI.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : Controller
    {

        private readonly IProductCollection db = new ProductCollection();



        [HttpGet]
        public async Task<IActionResult> GetAll()
        {

            return Ok(await db.GetAllProducts());
        }



        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(string id)
        {

            return Ok(await db.GetProductById(id));
        }



        [HttpPost]
        public async Task<IActionResult> Create([FromBody] Product product) 
        {

            if (product == null)
            {
                return BadRequest();
            }

            if (product.Name == string.Empty)
            {
                ModelState.AddModelError("Name", "The product shouldn't be empty");
            }

            await db.CreateProduct(product);

            return Created("Created", true);
        }




        [HttpPut("{id}")]
        public async Task<IActionResult> Update([FromBody] Product product, string id)
        {

            if (product == null)
            {
                return BadRequest();
            }

            if (product.Name == string.Empty)
            {
                ModelState.AddModelError("Name", "The product shouldn't be empty");
            }

            product.Id = new MongoDB.Bson.ObjectId(id);
            await db.UpdateProduct(product);

            return Created("Created", true);
        }



        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(string id)
        {

            await db.DeleteProduct(id);

            return NoContent(); //Success!
        }
    }
}
