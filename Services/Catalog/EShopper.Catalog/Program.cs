using System.Reflection;
using AutoMapper;
using E_Shopper.Catalog.Mapping;
using E_Shopper.Catalog.Services.CategoryServices;
using E_Shopper.Catalog.Services.ProductDetailServices;
using E_Shopper.Catalog.Services.ProductServices;
using E_Shopper.Catalog.Settings;
using Microsoft.Extensions.Options;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddOpenApi();

builder.Services.AddScoped<ICategoryService,CategoryService>();
builder.Services.AddScoped<IProductDetailService,ProductDetailService>();
builder.Services.AddScoped<IProductService,ProductService>();
builder.Services.AddScoped<IDatabaseSettings>(sp =>
{
    return sp.GetRequiredService<IOptions<DatabaseSettings>>().Value;
});

builder.Services.Configure<DatabaseSettings>(builder.Configuration.GetSection("DatabaseSettings"));

var mapperConfig = new MapperConfiguration(cfg =>
{
    cfg.AddProfile<GeneralMapping>();
});
var mapper = mapperConfig.CreateMapper();
builder.Services.AddSingleton(mapper);


builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
