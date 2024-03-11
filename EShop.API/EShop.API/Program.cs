using DataAccess.EShop.IServices;
using DataAccess.EShop.Services;
using DataAccess.EShop2.EntitiesFramework;
using DataAccess.EShop2.IServices;
using DataAccess.EShop2.Services;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);
var configuration = builder.Configuration;
// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
//configuration lấy tự khai báo ở trên
builder.Services.AddDbContext<EShopDbContext>(options => options.UseSqlServer(configuration.GetConnectionString("ConnStr")));// 'ConnStr' là ConnectionString trog file Program
builder.Services.AddTransient<IProductService, ProductService>();// nó sẽ quản lí việc khởi tạo của class Product
builder.Services.AddTransient<IPostService, PostService>();
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthorization();

app.MapControllers();

app.Run();
