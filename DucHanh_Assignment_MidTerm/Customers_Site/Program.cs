
using Customers_Site.Interfaces;
using Customers_Site.Services;

var builder = WebApplication.CreateBuilder(args);
//Config api
builder.Services.AddHttpClient("", option =>
{
    option.BaseAddress = new Uri(builder.Configuration["API"]);
});
// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddScoped<ICategory_Service,Category_Service>();
builder.Services.AddScoped<IProduct_Service, Product_Service>();
builder.Services.AddScoped<IRating_Service, Rating_Service>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
