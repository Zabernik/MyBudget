using Microsoft.EntityFrameworkCore;
using MyBudget.Controllers;
using MyBudget.Data;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<MyBudgetContext>(options =>
    options.UseSqlite(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddControllersWithViews();
builder.Services.AddScoped<DepositsController>();

var app = builder.Build();

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

using (var scope = app.Services.CreateScope())
{
    var depositController = scope.ServiceProvider.GetRequiredService<DepositsController>();

    await depositController.PrepareDepositData();

    depositController.RunPythonScript();
}

app.Run();
