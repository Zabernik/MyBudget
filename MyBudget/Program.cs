using Microsoft.EntityFrameworkCore;
using MyBudget.Data;

var builder = WebApplication.CreateBuilder(args);

// Dodaj DbContext do kontenera DI (musi byæ przed builder.Build())
builder.Services.AddDbContext<MyBudgetContext>(options =>
    options.UseSqlite(builder.Configuration.GetConnectionString("DefaultConnection")));

// Dodaj inne serwisy (np. kontrolery, us³ugi, itd.)
builder.Services.AddControllersWithViews();

var app = builder.Build(); // Aplikacja zostaje zbudowana tutaj

// Konfiguracja aplikacji po jej zbudowaniu
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
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
