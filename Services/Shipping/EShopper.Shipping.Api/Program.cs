using AutoMapper;
using EShopper.Shipping.BusinessLayer.Abstract;
using EShopper.Shipping.BusinessLayer.Managers;
using EShopper.Shipping.DataAccessLayer.Abstract;
using EShopper.Shipping.DataAccessLayer.Data;
using EShopper.Shipping.DataAccessLayer.EntityFramework;
using EShopper.Shipping.EntityLayer.Domain;
using EShopper.Shipping.MappingLayer.Mapping.CargoCompanyMapping;
using EShopper.Shipping.MappingLayer.Mapping.CargoCustomerMapping;
using EShopper.Shipping.MappingLayer.Mapping.CargoDetailMapping;
using EShopper.Shipping.MappingLayer.Mapping.CargoOperationMapping;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;

var builder = WebApplication.CreateBuilder(args);


builder.Services.AddControllers();
builder.Services.AddDbContext<CargoContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));
});

builder.Services.AddScoped<ICargoCompanyDal,EfCargoCompanyDal>();
builder.Services.AddScoped<ICargoCompanyService,CargoCompanyManager>();
builder.Services.AddScoped<ICargoCustomerDal,EfCargoCustomerDal>();
builder.Services.AddScoped<ICargoCustomerService,CargoCustomerManager>();
builder.Services.AddScoped<ICargoDetailService,CargoDetailManager>();
builder.Services.AddScoped<ICargoOperationService,CargoOperationManager>();
builder.Services.AddScoped<ICargoDetailDal,EfCargoDetailDal>();
builder.Services.AddScoped<ICargoOperationDal,EfCargoOperationDal>();

var mapperConfig = new MapperConfiguration(cfg =>
{
    cfg.AddProfile<CargoCompanyMapper>();
    cfg.AddProfile<CargoCustomerMapper>();
    cfg.AddProfile<CargoDetailMapper>();
    cfg.AddProfile<CargoOperationMapper>();
});
var mapper = mapperConfig.CreateMapper();
builder.Services.AddSingleton(mapper);

builder.Services.AddOpenApi();

builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme).AddJwtBearer(options =>
{
    options.Authority = builder.Configuration["IdentityServerUrl"];
    options.Audience = "ResourceOrder";
});

builder.Services.AddAuthorization(options =>
{
    options.AddPolicy("CargoFullAccess", policy =>
    {
        policy.RequireClaim("scope", "CargoFullPermisson");
    });
});


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

app.UseAuthorization();

app.MapControllers();

app.Run();
