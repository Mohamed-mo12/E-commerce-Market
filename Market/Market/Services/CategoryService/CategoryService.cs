using Market.Data;
using Market.DTO.Categories;
using Market.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace Market.Services.CategoryService
{
    public class CategoryService : ICategoryService
    {
        private readonly ApplicationDbContext context;

        public CategoryService(ApplicationDbContext context)
        {
            this.context = context;
        }
        public async Task<IEnumerable<CategoryDataDTO>> AllCatgeory()
        {
            var category = await context.Categories.AsNoTracking().ToListAsync();
            if (category.Any())
            {
                var Cat = category.Select(x => new CategoryDataDTO
                {
                    Name = x.Name

                });
                return Cat; 
            }

            return new List<CategoryDataDTO>(); 
            

        }

        public async Task<Category> Create(CategoryDataDTO category)
        {

            if (string.IsNullOrEmpty(category.Name))
            {
                return null; 
            }

            var AddCategory = new Category
            {
                Name = category.Name
            };

            await context.Categories.AddAsync(AddCategory);
            await context.SaveChangesAsync();
            return AddCategory; 

        }

        public async Task<bool> Delete(int id)
        {
            var DeleteCat = await context.Categories.FirstOrDefaultAsync(x => x.ID == id);
            if (DeleteCat !=null )
            {
                context.Categories.Remove(DeleteCat);
                await context.SaveChangesAsync();
                return true; 
            }

            return false; 
        }

        public async Task<IEnumerable<CategoriesWithProductsDataDTO>> GetCategoriesWithProducts()
        {
            var Catewithpro = await context.Categories.Include(x =>x.products)
                .ToListAsync();
            if (Catewithpro.Any())
            {
                var result = Catewithpro.SelectMany(c => c.products.Select(p => new CategoriesWithProductsDataDTO
                {
                     Category_name = c.Name,
                     product_name = p.Name

                }));
                return result; 
            }
            return Enumerable.Empty<CategoriesWithProductsDataDTO>(); 
        }

        public async Task<CategoryDataDTO> GetCategoryByID(int id)
        {
            var OneCategory = await context.Categories.AsNoTracking()
                .FirstOrDefaultAsync(x => x.ID == id);
            if (OneCategory!=null)
            {
                var cate = new CategoryDataDTO
                {
                    Name = OneCategory.Name
                };
                return cate; 
            }

            return null;  
        }

        public IEnumerable<CategoryDataDTO>? SerachCategory(string name)
        {
            if (string.IsNullOrEmpty(name))
            {
                return Enumerable.Empty<CategoryDataDTO>(); // it will return emprty collection 
            }

            var Search =  context.Categories.Where(x => x.Name.Contains(name));
            var categoryDTO =  Search.Select(x => new CategoryDataDTO {
              Name  = x.Name 
            }).ToList();

            return categoryDTO; 
        }

        public async Task<Category> Update(int id , CategoryDataDTO category)
        {
            var UpdateCat = await context.Categories.FirstOrDefaultAsync(x=>x.ID==id);
            if (UpdateCat == null)
            {
                return null;
            }
            if (string.IsNullOrEmpty(category.Name))
            {
                return null; 
            }
            UpdateCat.Name = category.Name;
            await context.SaveChangesAsync();
            return UpdateCat;
        }
    }
}
