using Market.DTO.Products;
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


                logger.LogError(ex.Message, "Error occurred while getting Product by name");
                return StatusCode(500, "Internal server error");
            }
        }

        [HttpPost("Create",Name ="CreateProduct")]
        public async Task<IActionResult> Create(CreateProdcutDataDTO prodcutDataDTO) {

            try
            {
                if (ModelState.IsValid)
                {
                    var add = await _product.Create(prodcutDataDTO);
                    if (add!=null)
                    {
                        var url = Url.Link("CreateProduct", new { id = add.ID });
                        return Created(url, add); 
                    }
                    return BadRequest(" Invalid Add Product ");
                   
                }
                return BadRequest(ModelState);

            }
            catch (Exception ex)
            {
                logger.LogError(ex.Message, "Error occurred");
                return StatusCode(500, "Internal server error");
            }
        }

        [HttpPut("{id:int}/product",Name ="UpdateProduct")]
        public async Task<IActionResult> update(int id,[FromForm]UpdateProductDataDTO updateProduct) 
        {

            try
            {
                if (ModelState.IsValid)
                {
                    var update = await _product.Update(id, updateProduct);
                    if (update!=null)
                    {
                        var url = Url.Link("UpdateProduct", new { id = update.ID });
                        return Created(url, update); 
                    }
                    return NotFound("Product Not Found"); 
                }
                return BadRequest(ModelState);
                 

            }
            catch (Exception ex )
            {
                logger.LogError(ex.Message, "Error occurred ");
                return StatusCode(500, "Internal server error");
            }
        
        
        }

        [HttpDelete("{id:int}/Delete")]
        public async Task<IActionResult> Delete(int id) {

            try
            {
                var Deleteprod = await _product.Delete(id);
                if (Deleteprod==true)
                {
                    return NoContent(); 
                }
                return NotFound(" Invalid Deleted it ");
            }
            catch (Exception ex )
            {

                logger.LogError(ex.Message, "Error occurred ");
                return StatusCode(500, "Internal server error");
            }
        
        
        }
    }
}
