using API.Data;
using API.Interfaces;
using API.Mapping;
using API.Repositories;
using Microsoft.EntityFrameworkCore;
var MyAllowSpecificOrigins = "_myAllowSpecificOrigins";

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
builder.Services.AddAutoMapper(typeof(Rating_Mapping).Assembly);
builder.Services.AddScoped<IRating_Repository, Rating_Repository>();
builder.Services.AddAutoMapper(typeof(Customer_Mapping).Assembly);
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddCors(options =>
{
    options.AddPolicy(name: MyAllowSpecificOrigins,
                      policy =>
                      {
                          policy.WithOrigins("http://localhost:3000").
                          AllowAnyHeader()
                         .AllowAnyMethod();
                      });
});
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseCors(MyAllowSpecificOrigins);

app.UseAuthorization();

app.MapControllers();

app.Run();
