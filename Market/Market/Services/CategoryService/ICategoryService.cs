using Market.DTO.Categories;
using Market.Model;

namespace Market.Services.CategoryService
{
    public interface ICategoryService
    {
        // For Customer
        Task<IEnumerable<CategoryDataDTO>> AllCatgeory();
        Task<CategoryDataDTO> GetCategoryByID(int id);
        Task<IEnumerable<CategoriesWithProductsDataDTO>> GetCategoriesWithProducts();
        IEnumerable<CategoryDataDTO> SerachCategory(string name); 

        // For Admins 
        Task<Category> Create(CategoryDataDTO category);
        Task<Category> Update(int id, CategoryDataDTO category);
        Task<bool> Delete(int id);
        

    }
}
