using Accessors.Interfaces;
using Accessors.Classes;
using Managers.Interfaces;
using Managers.Interfaces;
using Engines;
using Engines.Interfaces;
using Managers;
var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();

builder.Services.AddScoped<IProductAccessor, ProductAccessor>();
builder.Services.AddScoped<IUserAccessor, UserAccessor>();
builder.Services.AddScoped<ICategoryAccessor, CategoryAccessor>();
builder.Services.AddScoped<ICartAccessor, CartAccessor>();
builder.Services.AddScoped<ISaleAccessor, SaleAccessor>();
builder.Services.AddScoped<IProductManager, ProductManager>();
builder.Services.AddScoped<IProductEngine, ProductEngine>();

builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowReactApp",
        policy => policy.WithOrigins("http://localhost:3000")
                        .AllowAnyHeader()
                        .AllowAnyMethod());
});

var app = builder.Build();
app.UseCors("AllowReactApp");
app.MapControllers();
app.Run();




