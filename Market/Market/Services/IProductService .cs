using Market.DTO.Products;

namespace Market.Services
{
    public interface IProductService
    {
        IEnumerable<ProductDataDTO> AllProduct();
        Task<ProductDataDTO> GetByID(int id );
        IEnumerable<ProdcutSearchDataDTo> Serach(string name);
    }
}
