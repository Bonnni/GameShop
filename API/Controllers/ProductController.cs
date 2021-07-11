using System;
using System.Linq;
using System.Threading.Tasks;
using BuissenesLayer.Interfaces;
using DataLayer.Entities;
using Microsoft.AspNetCore.Mvc;

namespace Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProductRepository _productRepository;

        public ProductController(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        // GET: api/product/getproducts
        [HttpGet]
        [Route("GetProducts")]
        public async Task<IActionResult> GetProducts()
        {
            try
            {
                var products = await _productRepository.GetProducts();
                if (products == null)
                {
                    return NotFound();        
                }
                return Ok(products);
            }
            catch (Exception)
            {
                return BadRequest();
            }
            
        }

        // GET: api/product/getproduct/id
        [HttpGet]
        [Route("GetProduct/{id}")]
        public async Task<IActionResult> GetProduct(int? id)
        {
            if (id == null)
            {
                return BadRequest();        
            }

            try
            {
                var product = await _productRepository.GetProduct(id);
                if (product == null)
                {
                    return NotFound();
                }

                return Ok(product);
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }

        // GET: api/product/getproduct/genre
        [HttpGet]
        [Route("GetProduct/{genre}")]
        public async Task<IActionResult> GetProduct(string genre)
        {
            if (genre == null)
            {
                return BadRequest();
            }

            try
            {
                var product = await _productRepository.GetProductByGenre(genre);
                if (product == null)
                {
                    return NotFound();
                }

                return Ok(product);
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }

        // POST: api/product/updateproduct
        [HttpPost]
        [Route("UpdateProduct")]
        public async Task<IActionResult> UpdateProduct([FromBody] Product product)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    await _productRepository.UpdateProduct(product);
                    return Ok();
                }
                catch (Exception ex)
                {
                    if (ex.GetType().FullName == "Microsoft.EntityFrameworkCore.DbUpdateConcurrencyException")
                    {
                        return NotFound();
                    }

                    return BadRequest();
                }
            }
            return BadRequest();
        }

        // POST: api/product/deleteproduct/id
        [HttpPost]
        [Route("DeleteProduct/{id}")]
        public async Task<IActionResult> DeleteProduct(int? id)
        {
            int result = 0;

            if (id == null)
            {
                return BadRequest();
            }

            try
            {
                result = await _productRepository.DeleteProduct(id);
                if (result == 0)
                {
                    return NotFound();
                }
                return Ok();
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }

        // POST: api/product/addproduct
        [HttpPost]
        [Route("AddProduct")]
        public async Task<IActionResult> AddProduct([FromBody] Product product)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    var productId = await _productRepository.CreateProduct(product);
                    if (productId > 0)
                    {
                        return Ok(productId);
                    }
                    else
                    {
                        return NotFound();
                    }
                }
                catch (Exception)
                {
                    return BadRequest();
                }
            }
            return BadRequest();
        }

    }
}
