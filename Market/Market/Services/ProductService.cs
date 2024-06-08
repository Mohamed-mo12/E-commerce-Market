using Market.Data;
using Market.DTO.Products;
using Microsoft.EntityFrameworkCore;

namespace Market.Services
{
    public class ProductService : IProductService
    {
        private readonly ApplicationDbContext context;

        public ProductService(ApplicationDbContext context)
        {
            this.context = context;
        }
        public IEnumerable<ProductDataDTO> AllProduct()
        {
            var All = context.Products.Include(x => x.Category)
                .AsNoTracking().ToList();
            var productData = All.Select(x => new ProductDataDTO { 
            
              Name = x.Name, 
              Description = x.Description,
              Price= x.Price,
              Category_name = x.Category.Name,
              Image= x.Image 
            
            }).ToList();

            return productData; 
        }

        public async Task<ProductDataDTO> GetByID(int id)
        {
            var Oneprod =await context.Products.Include(x => x.Category)
                .AsNoTracking().FirstOrDefaultAsync(x => x.ID == id);
            if (Oneprod == null )
            {
                return null; 
            }

            var productData = new ProductDataDTO { 
             Name = Oneprod.Name , 
             Description = Oneprod.Description,
             Category_name= Oneprod.Category.Name,
             Image = Oneprod.Image,
             Price = Oneprod.Price
            
            };
            return productData; 
        }

        public IEnumerable<ProdcutSearchDataDTo> Serach(string name)
        {
            var Search = context.Products.Where(x => x.Name.Contains(name));
            if (Search==null )
            {
                return null; 
            }

            var productData = Search.Select(x => new ProdcutSearchDataDTo
            {
                 
                 Name = x.Name,
                 Category_name = x.Category.Name

            });

            return productData;
        }
    }
}
