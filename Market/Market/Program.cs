using Market.Data;
using Market.Services;
using Market.Services.CategoryService;
using Market.Services.ShippingCartService;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
string connection = builder.Configuration.GetConnectionString("MyDB");

builder.Services.AddDbContext<ApplicationDbContext>(option =>
{
    option.UseSqlServer(connection);
});

builder.Services.AddLogging();
builder.Services.AddAutoMapper(typeof(Program));

builder.Services.AddScoped<IProductService, ProductService>();
builder.Services.AddScoped<ICategoryService, CategoryService>();
builder.Services.AddScoped<IShoppingCartService, ShoppingCartService>(); 


builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthentication();

app.UseAuthorization();

app.MapControllers();

app.Run();
