using Microsoft.EntityFrameworkCore;
using Mission06_LastName.Data; // keep this if your project namespace is still Mission06_LastName
// Creates the web application builder
var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllersWithViews();

// Configures Entity Framework to use SQLite database
builder.Services.AddDbContext<MovieCollectionContext>(options =>
    options.UseSqlite(builder.Configuration.GetConnectionString("MovieConnection")));

var app = builder.Build();

// Adds global error handling for production
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
}

// Enables serving static files (CSS, JS, images)
app.UseStaticFiles();
app.UseRouting();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();