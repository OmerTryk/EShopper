using AutoMapper;
using E_Shopper.Catalog.Mapping;
using E_Shopper.Catalog.Services.AboutServices;
using E_Shopper.Catalog.Services.CategoryServices;
using E_Shopper.Catalog.Services.ContactServices;
using E_Shopper.Catalog.Services.FeatureServices;
using E_Shopper.Catalog.Services.FeaturesSliderServices;
using E_Shopper.Catalog.Services.OfferServices;
using E_Shopper.Catalog.Services.ProductDetailServices;
using E_Shopper.Catalog.Services.ProductServices;
using E_Shopper.Catalog.Services.VendorBrandServices;
using E_Shopper.Catalog.Settings;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.Extensions.Options;
using Microsoft.OpenApi.Models;

namespace E_Shopper.Catalog.Extensions
{
    public static class ServiceRegistration
    {
        public static IServiceCollection AddEShopperCatalogServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme).AddJwtBearer(options =>
            {
                options.Authority = configuration["IdentityServiceUrl"];
                options.Audience = "ResourceCatalog";
            });

            services.AddAuthorization(options =>
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
            services.AddScoped<ICategoryService, CategoryService>();
            services.AddScoped<IProductDetailService, ProductDetailService>();
            services.AddScoped<IProductService, ProductService>();
            services.AddScoped<IFeatureSliderService, FeatureSliderService>();
            services.AddScoped<IFeatureService, FeatureService>();
            services.AddScoped<IOfferService, OfferService>();
            services.AddScoped<IVendorBrandService, VendorBrandService>();
            services.AddScoped<IAboutService, AboutService>();
            services.AddScoped<IContactService, ContactService>();
            services.AddScoped<IDatabaseSettings>(sp =>
            {
                return sp.GetRequiredService<IOptions<DatabaseSettings>>().Value;
            });

            services.Configure<DatabaseSettings>(configuration.GetSection("DatabaseSettings"));

            var mapperConfig = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile<GeneralMapping>();
            });
            var mapper = mapperConfig.CreateMapper();
            services.AddSingleton(mapper);


            services.AddEndpointsApiExplorer();
            services.AddSwaggerGen(c =>
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

            return services;
        }
    }
}
