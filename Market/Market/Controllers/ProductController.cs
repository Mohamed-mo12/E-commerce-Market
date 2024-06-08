using Market.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Market.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProductService _product;
        private readonly ILogger<ProductController> logger; 
        public ProductController(IProductService product, ILogger<ProductController> logger)
        {
            this._product = product;
            this.logger = logger; 
        }

        [HttpGet("Products")]
        public IActionResult All() {

            try
            {
                var prod = _product.AllProduct();
                if (prod!=null)
                {
                    return Ok(prod);
                }
                return NotFound(" No Products Found ");
            }
            catch (Exception ex )
            {
                logger.LogError(ex.Message,"Invalid operation");
                
                return StatusCode(500, " Error Througth operation  ");
            }

        
        }
        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetbyId(int id ) {

            try
            {
                var result = await _product.GetByID(id);
                if (result!=null)
                {
                    return Ok(result);
                }
                return NotFound(" Product Not Found ");
            }
            catch (Exception ex )
            {
                logger.LogError(ex.Message, "Error occurred while getting Product by id");
                return StatusCode(500, "Internal server error"); 
            }

        }
        [HttpGet("Search")]
        public IActionResult Search(string name) {

            try
            {
                if (string.IsNullOrEmpty(name))
                {
                    return BadRequest(" Name Is Requierd ");
                }

                var productname = _product.Serach(name);
                if (productname!=null)
                {
                    return Ok(productname);
                }
                return NotFound(" Product Not Found ");
            }
            catch (Exception ex)
            {


                logger.LogError(ex.Message, "Error occurred while getting Product by id");
                return StatusCode(500, "Internal server error");
            }
        }
    }
}
