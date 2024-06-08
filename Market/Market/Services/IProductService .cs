using Market.DTO.Products;
using Market.Model;

namespace Market.Services
{
    public interface IProductService
    {
        // For Customer 
        IEnumerable<ProductDataDTO> AllProduct();
        Task<ProductDataDTO> GetByID(int id );
        IEnumerable<ProdcutSearchDataDTo> Serach(string name);
        // For Admin 
        Task<Product> Create(CreateProdcutDataDTO productData);

        Task<Product> Update(int id , UpdateProductDataDTO UpdateproductData);

        Task<bool> Delete(int id); 
    }
}
