using Microsoft.EntityFrameworkCore;
using Mission06_LastName.Data;
// Program.cs
var builder = WebApplication.CreateBuilder(args);

// Configures services and middleware for the Joel Hilton Film Collection web app.

builder.Services.AddControllersWithViews();
// Sets up MVC, connects to SQLite using Entity Framework Core,
builder.Services.AddDbContext<MovieCollectionContext>(options =>
    options.UseSqlite(builder.Configuration.GetConnectionString("MovieConnection")));

var app = builder.Build();

if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
}

app.UseStaticFiles();
app.UseRouting();

// Create DB / apply migrations / seed
using (var scope = app.Services.CreateScope())
{
    var services = scope.ServiceProvider;
    var context = services.GetRequiredService<MovieCollectionContext>();
    context.Database.Migrate();
    DbInitializer.Seed(context);
}

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();