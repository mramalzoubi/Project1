using Microsoft.EntityFrameworkCore;
using Yogagym.Models;
using Yogagym.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddDbContext<ModelContext>(options => options.UseOracle(builder.Configuration.GetConnectionString("YogagymConnection")));
builder.Services.AddSession(options => { options.IdleTimeout = TimeSpan.FromMinutes(60); });
// Add services to the container.
builder.Services.AddControllersWithViews();
// Register PagesViewService with the DI container
builder.Services.AddScoped<IPagesViewModel, PagesViewModel>();
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
app.UseSession();
app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
