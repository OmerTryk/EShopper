using System.Reflection;
using AutoMapper;
using E_Shopper.Catalog.Mapping;
using E_Shopper.Catalog.Services.CategoryServices;
using E_Shopper.Catalog.Services.ProductDetailServices;
using E_Shopper.Catalog.Services.ProductServices;
using E_Shopper.Catalog.Settings;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.Extensions.Options;
using Microsoft.OpenApi.Models;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddOpenApi();

builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme).AddJwtBearer(options =>
{
    options.Authority = builder.Configuration["IdentityServiceUrl"];
    options.Audience = "ResourceCatalog";
});

builder.Services.AddAuthorization(options =>
{
    options.AddPolicy("CatalogReadAccess", policy =>
    {
        policy.RequireClaim("scope", "CatalogReadPermission");
    });

    options.AddPolicy("CatalogFullAccess", policy =>
    {
        policy.RequireClaim("scope", "CatalogFullPermission");
    });
});


builder.Services.AddScoped<ICategoryService, CategoryService>();
builder.Services.AddScoped<IProductDetailService, ProductDetailService>();
builder.Services.AddScoped<IProductService, ProductService>();
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
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo { Title = "API", Version = "v1" });

    c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
    {
        Name = "Authorization",
        In = ParameterLocation.Header,
        Type = SecuritySchemeType.ApiKey,
        Scheme = "Bearer"
    });
    c.AddSecurityRequirement(new OpenApiSecurityRequirement()
    {
        {
            new OpenApiSecurityScheme
            {
                Reference = new OpenApiReference
                {
                    Type=ReferenceType.SecurityScheme,
                    Id="Bearer"
                },
                Scheme="oauth2",
                Name="Bearer",
                In=ParameterLocation.Header
            },
            new List<string>()
        }
    });
});

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.UseHttpsRedirection();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();
