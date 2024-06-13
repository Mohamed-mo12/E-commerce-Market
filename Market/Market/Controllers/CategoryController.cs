using Market.DTO.Categories;
using Market.Services.CategoryService;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

namespace Market.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private readonly ICategoryService category;
        private readonly ILogger<CategoryController> logger;

        public CategoryController(ICategoryService category,
            ILogger<CategoryController> logger)
        {
            this.logger = logger; 
            this.category = category;
        }

        [HttpGet("AllCategory")]
        public async Task<IActionResult> Category() 
        {
            try
            {
                var cat = await category.AllCatgeory();
                if (cat.Any())
                {
                    return Ok(cat);
                }
                return NotFound();
                
            }
            catch (Exception ex )
            {

                logger.LogError(ex, "An error occurred while retrieving categories.");
                return StatusCode(500, "Internal server error");
            }
        }

        [HttpGet("{id:int}/Category")]
        public async Task<IActionResult> GetcategoryByid(int id ) {

            try
            {
                var onecat = await category.GetCategoryByID(id);
                if (onecat!=null)
                {
                    return Ok(onecat); 
                }
                return NotFound(" Category Not Found ");
            }
            catch (Exception ex )
            {

                logger.LogError(ex, "An error occurred while retrieving categories.");
                return StatusCode(500, "Internal server error");
            }

        }


        [HttpPost("Add",Name = "categoryAdd")]
        public async Task<IActionResult> Create(CategoryDataDTO categoryData ) {

            try
            {
                if (ModelState.IsValid)
                {
                    var categ = await category.Create(categoryData);
                    var url = Url.Link("categoryAdd", new { id = categ.ID });
                    return Created(url,categ);
                }
                return BadRequest(ModelState);
            }
            catch (Exception ex)
            {

                logger.LogError(ex, "An error occurred .");
                return StatusCode(500, "Internal server error");
            }
        
        }

        [HttpPut("{id:int}/Update",Name ="UpdateCategory")]
        public async Task<IActionResult> Update(int id, CategoryDataDTO categoryData) 
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var Updatecat = await category.Update(id,categoryData);
                    if (Updatecat!=null)
                    {
                        var url = Url.Link("UpdateCategory", new {id = Updatecat.ID});
                        return Created(url,Updatecat); 
                    }

                    return NotFound(new {message = "Category Not Exist"});
                }
                return BadRequest(ModelState); 
            }
            catch (Exception ex)
            {
                logger.LogError(ex, "An error occurred.");
                return StatusCode(500,"Internal server error");
            }
        
        }

        [HttpDelete("{id:int}/Delete")]
        public async Task<IActionResult> Delete(int id ) {

            try
            {
                var Del = await category.Delete(id);
                if (Del !=null )
                {
                    return NoContent(); 
                }
                return NotFound(new { message = " Category Not Found "}); 
            }
            catch (Exception ex )
            {

                logger.LogError(ex, "An error occurred.");
                return StatusCode(500, "Internal server error");
            }
        
        }

        [HttpGet("CategoryWithProduct")]
        public async Task<IActionResult> CategoryWithProduct() {

            try
            {
                var Categwithprod = await category.GetCategoriesWithProducts();
                if (Categwithprod!=null)
                {
                    return Ok(Categwithprod);
                }

                return NotFound(" No Category and product Exist ");
            }
            catch (Exception ex)
            {
                logger.LogError(ex, "An error occurred while retrieving categories with Product.");
                return StatusCode(500, "Internal server error");

            }
        
        
        
        }

        [HttpGet("Serach")]
        public IActionResult Search(string name)
        {
            try
            {
                var result = category.SerachCategory(name);
                if (result!=null)
                {
                    return Ok(result);
                }
                return NotFound("Category Not Found"); 
            }
            catch (Exception ex)
            {
                logger.LogError(ex, "An error occurred while retrieving category.");
                return StatusCode(500, "Internal server error");

            }

        }
    }
}
