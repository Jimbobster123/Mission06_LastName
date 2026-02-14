using Microsoft.EntityFrameworkCore;
using Mission06_LastName.Data;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllersWithViews();

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