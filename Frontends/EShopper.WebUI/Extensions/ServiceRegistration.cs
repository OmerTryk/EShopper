using EShopper.WebUI.Handlers;
using EShopper.WebUI.Services.BasketService;
using EShopper.WebUI.Services.CatalogService.AboutService;
using EShopper.WebUI.Services.CatalogService.CategoryService;
using EShopper.WebUI.Services.CatalogService.ContactService;
using EShopper.WebUI.Services.CatalogService.FeatureService;
using EShopper.WebUI.Services.CatalogService.FeatureSliderServices;
using EShopper.WebUI.Services.CatalogService.OfferServices;
using EShopper.WebUI.Services.CatalogService.ProductDetailServices;
using EShopper.WebUI.Services.CatalogService.ProductService;
using EShopper.WebUI.Services.CatalogService.VendorBrandServices;
using EShopper.WebUI.Services.Concrete;
using EShopper.WebUI.Services.Interfaces;
using EShopper.WebUI.Services.MessageService;
using EShopper.WebUI.Services.OrderService.OrderAddressService;
using EShopper.WebUI.Settings;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication.JwtBearer;

namespace EShopper.WebUI.Extensions
{
    public static class ServiceRegistration
    {
        public static IServiceCollection AddEShopperServices(this IServiceCollection services, IConfiguration configuration)
        {
            // 🔹 Authentication
            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
                .AddCookie(JwtBearerDefaults.AuthenticationScheme, opt =>
                {
                    opt.LoginPath = "/Login/Index/";
                    opt.LogoutPath = "/Login/LogOut/";
                    opt.AccessDeniedPath = "/Pages/AccessDenied/";
                    opt.Cookie.HttpOnly = true;
                    opt.Cookie.SameSite = SameSiteMode.Strict;
                    opt.Cookie.SecurePolicy = CookieSecurePolicy.SameAsRequest;
                    opt.Cookie.Name = "EShopperJwt";
                });

            services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
                .AddCookie(CookieAuthenticationDefaults.AuthenticationScheme, options =>
                {
                    options.LoginPath = "";
                    options.ExpireTimeSpan = TimeSpan.FromDays(4);
                    options.Cookie.Name = "EShopperCookie";
                    options.SlidingExpiration = true;
                });
            // 🔹 Http AccessToken Management
            services.AddAccessTokenManagement();

            // 🔹 Http Context & Services
            services.AddHttpContextAccessor();
            services.AddScoped<IUserService, UserService>();
            services.AddScoped<ICategoryService, CategoryService>();
            services.AddScoped<IProductService, ProductService>();
            services.AddScoped<IContactService, ContactService>();
            services.AddScoped<IFeatureService, FeatureService>();
            services.AddScoped<IFeatureSliderService, FeatureSliderService>();
            services.AddScoped<IOfferService, OfferService>();
            services.AddScoped<IProductDetailService, ProductDetailService>();
            services.AddScoped<IVendorBrandService, VendorBrandService>();
            services.AddScoped<IAboutService, AboutService>();
            services.AddHttpClient<IIdentityService, IdentityService>();

            // 🔹 Handlers
            services.AddScoped<ResourceOwnerPasswordTokenHandler>();
            services.AddScoped<ClientCredentialTokenHandler>();

            // 🔹 Token Services
            services.AddHttpClient<IClientCredentialTokenService, ClientCredentialTokenService>();

            // 🔹 Settings
            services.Configure<ClientSetting>(configuration.GetSection("ClientSettings"));
            services.Configure<ServiceApiSettings>(configuration.GetSection("ServiceApiSettings"));

            // 🔹 Cache & Session
            services.AddDistributedMemoryCache();
            services.AddSession();

            // 🔹 Http Clients with Delegating Handlers
            var values = configuration.GetSection("ServiceApiSettings").Get<ServiceApiSettings>();

            services.AddHttpClient<IUserService, UserService>(opt =>
            {
                opt.BaseAddress = new Uri(values.IdentityServerUrl);
            }).AddHttpMessageHandler<ResourceOwnerPasswordTokenHandler>();

            services.AddHttpClient<ICategoryService, CategoryService>(options =>
            {
                options.BaseAddress = new Uri($"{values.OcelotUrl}/{values.Catalog.Path}");
            }).AddHttpMessageHandler<ClientCredentialTokenHandler>();

            services.AddHttpClient<IBasketService, BasketService>(options =>
            {
                options.BaseAddress = new Uri($"{values.OcelotUrl}/{values.Basket.Path}");
            }).AddHttpMessageHandler<ClientCredentialTokenHandler>();

            services.AddHttpClient<IOrderAddressService, OrderAddressService>(options =>
            {
                options.BaseAddress = new Uri($"{values.OcelotUrl}/{values.Order.Path}");
            }).AddHttpMessageHandler<ClientCredentialTokenHandler>();

            services.AddHttpClient<IMessageService, MessageService>(options =>
            {
                options.BaseAddress = new Uri($"{values.OcelotUrl}/{values.Message.Path}");
            });
            return services;
        }
    }
}
