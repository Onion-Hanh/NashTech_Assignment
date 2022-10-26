using API.Data;
using API.Interfaces;
using API.Mapping;
using API.Repositories;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();

//config service connectionstring
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");

builder.Services.AddDbContext<DrugStoreDBContext>(options =>
{
    options.UseSqlServer(connectionString);
});
//config automapper
builder.Services.AddAutoMapper(typeof(Category_Mapping).Assembly);
builder.Services.AddScoped<ICategory_Repository, Category_Repository>();
builder.Services.AddAutoMapper(typeof(Product_Mapping).Assembly);
builder.Services.AddScoped<IProduct_Repository, Product_Repository>();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
