using Market.Data;
using Market.DTO.Products;
using Market.Model;
using Microsoft.EntityFrameworkCore;
using static System.Net.Mime.MediaTypeNames;

namespace Market.Services
{
    public class ProductService : IProductService
    {
        private readonly ApplicationDbContext context;
        private readonly IWebHostEnvironment webHostEnvironment;
        private readonly string _imagepath;

        public ProductService(ApplicationDbContext context,
            IWebHostEnvironment webHostEnvironment)
        {
            this.webHostEnvironment = webHostEnvironment; 
            this.context = context;
            this._imagepath = $"{webHostEnvironment.WebRootPath}/assets/image/product";
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

        public async Task<Product> Create(CreateProdcutDataDTO productData)
        {
           var imagename = $"{Guid.NewGuid()}{Path.GetExtension(productData.Image.FileName)}";
           var imagepath = Path.Combine(_imagepath, imagename);

            using var stream = File.Create(imagepath);
            await productData.Image.CopyToAsync(stream); 

            var product = new Product
            {

                Name = productData.Name,
                Image = imagename,
                Price = productData.Price,
                Description = productData.Description,
                Category_ID = productData.Category_id

            };
            context.Products.Add(product);
            await context.SaveChangesAsync();
            return product; 
        }

        public async Task<bool> Delete(int id)
        {
            var ProductName = await context.Products.FindAsync(id);
            if (ProductName==null)
            {
                return false;
            }
            context.Products.Remove(ProductName);
            await context.SaveChangesAsync(); 
            return true; 
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

        public async Task<Product> Update(int  id, UpdateProductDataDTO UpdateproductData)
        {
            var imagename = $"{Guid.NewGuid()}{Path.GetExtension(UpdateproductData.Image.FileName)}";
            var imagepath = Path.Combine(_imagepath, imagename);

            using var stream = File.Create(imagepath);
            await UpdateproductData.Image.CopyToAsync(stream);

            var prod = await context.Products.Include(x => x.Category)
                      .FirstOrDefaultAsync(x => x.ID == id); 
            if (prod == null)
            {
                return null;
            }

            prod.Image = imagename;
            prod.Description = UpdateproductData.Description;
            prod.Price = UpdateproductData.Price;

            if (string.IsNullOrEmpty(UpdateproductData.Name))
            {
                return null; 
            }

            prod.Name = UpdateproductData.Name;
            await context.SaveChangesAsync();
            return prod; 

        }
    }
}
