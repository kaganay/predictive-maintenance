using Microsoft.EntityFrameworkCore;
using PredictiveMaintenance.Application.DependencyInjection;
using PredictiveMaintenance.Infrastructure.Data;
using PredictiveMaintenance.Infrastructure.DependencyInjection;
using PredictiveMaintenance.Web.Hubs;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container
builder.Services.AddControllersWithViews();
builder.Services.AddSignalR();

// Infrastructure services
builder.Services.AddInfrastructureServices(builder.Configuration);

// Application services
builder.Services.AddApplicationServices();

var app = builder.Build();

// Configure the HTTP request pipeline
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
    pattern: "{controller=Dashboard}/{action=Index}/{id?}");

app.MapHub<NotificationHub>("/notificationHub");

// Ensure database exists & seed demo data
using (var scope = app.Services.CreateScope())
{
    var services = scope.ServiceProvider;
    try
    {
        var context = services.GetRequiredService<ApplicationDbContext>();
        context.Database.EnsureCreated();
        DataSeeder.SeedAsync(context).GetAwaiter().GetResult();
    }
    catch (Exception ex)
    {
        var logger = services.GetRequiredService<ILogger<Program>>();
        logger.LogError(ex, "An error occurred while ensuring the database is created and seeded.");
    }
}

app.Run();
