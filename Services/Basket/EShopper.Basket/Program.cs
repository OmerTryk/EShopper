using System.IdentityModel.Tokens.Jwt;
using EShopper.Basket.LoggingService;
using EShopper.Basket.Services;
using EShopper.Basket.Settings;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc.Authorization;
using Microsoft.Extensions.Options;
using Microsoft.OpenApi.Models;

var builder = WebApplication.CreateBuilder(args);

var requireAuthorizePolicy = new AuthorizationPolicyBuilder().RequireAuthenticatedUser().Build();

builder.Services.AddControllers(opt =>
{
    opt.Filters.Add(new AuthorizeFilter(requireAuthorizePolicy));
});

builder.Services.AddOpenApi();

JwtSecurityTokenHandler.DefaultInboundClaimTypeMap.Clear();

builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme).AddJwtBearer(options =>
{
    options.Authority = builder.Configuration["IdentityServerUrl"];
    options.Audience = "ResourceBasket";
});

builder.Services.AddAuthorization(options =>
{
    options.AddPolicy("BasketFullAccess", policy =>
    {
        policy.RequireClaim("scope", "BasketFullPermission");
    });
});


builder.Services.AddHttpContextAccessor();
builder.Services.AddScoped<IBasketService, BasketService>();
builder.Services.AddScoped<ILoginService, LoginService>();
builder.Services.Configure<RedisSettings>(builder.Configuration.GetSection("RedisSettings"));
builder.Services.AddSingleton<RedisService>(sp =>
{
    var redissettings = sp.GetRequiredService<IOptions<RedisSettings>>().Value;
    var redis = new RedisService(redissettings.Host, redissettings.Port);
    redis.Connect();
    return redis;
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

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();
