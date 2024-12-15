using Accessors.Interfaces;
using Accessors.Classes;    
var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();

builder.Services.AddScoped<IProductAccessor, ProductAccessor>();
builder.Services.AddScoped<IUserAccessor, UserAccessor>();
builder.Services.AddScoped<ICategoryAccessor, CategoryAccessor>();
builder.Services.AddScoped<ICartAccessor, CartAccessor>();
builder.Services.AddScoped<ISaleAccessor, SaleAccessor>();

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




