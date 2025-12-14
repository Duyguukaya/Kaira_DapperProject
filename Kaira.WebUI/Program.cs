using Kaira.WebUI.Context;
using Kaira.WebUI.Repositories.CategoryRepositories;
using Kaira.WebUI.Repositories.CollectionRepositories;
using Kaira.WebUI.Repositories.MarkaRepositories;
using Kaira.WebUI.Repositories.ProductRepositories;
using Kaira.WebUI.Repositories.TestimonialRepositories;
using Kaira.WebUI.Repositories.VideoRepositories;
using Microsoft.AspNetCore.Authentication.Cookies; 

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.


builder.Services.AddScoped<ICategoryRepository, CategoryRepository>();
builder.Services.AddScoped<IProductRepository, ProductRepository>();
builder.Services.AddScoped<ICollectionRepository, CollectionRepository>();
builder.Services.AddScoped<IMarkaRepository, MarkaRepository>();
builder.Services.AddScoped<ITestimonialRepository, TestimonialRepository>();
builder.Services.AddScoped<IVideoRepository, VideoRepository>();

builder.Services.AddScoped<AppDbContext>();

builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
    .AddCookie(options =>
    {
        options.LoginPath = "/Login/Index"; 
        options.ExpireTimeSpan = TimeSpan.FromMinutes(20); 
        options.SlidingExpiration = true; 
        options.AccessDeniedPath = "/Login/Index"; 
    });

builder.Services.AddControllersWithViews();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();


app.UseRouting();

app.UseAuthentication(); 
app.UseAuthorization();  

app.MapStaticAssets();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}")
    .WithStaticAssets();

app.Run();