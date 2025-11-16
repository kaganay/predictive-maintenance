using Microsoft.EntityFrameworkCore;
using PredictiveMaintenance.Application.DependencyInjection;
using PredictiveMaintenance.Infrastructure.Data;
using PredictiveMaintenance.Infrastructure.DependencyInjection;
using PredictiveMaintenance.API.Hubs;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddSignalR();

// CORS for local web app
const string DashboardCors = "DashboardCors";
builder.Services.AddCors(options =>
{
    options.AddPolicy(DashboardCors, policy =>
        policy.WithOrigins("http://localhost:5003")
              .AllowAnyHeader()
              .AllowAnyMethod()
              .AllowCredentials());
});

// Infrastructure & Application services
builder.Services.AddInfrastructureServices(builder.Configuration);
builder.Services.AddApplicationServices();

var app = builder.Build();

// Configure the HTTP request pipeline
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors(DashboardCors);
app.UseHttpsRedirection();
app.UseAuthorization();

app.MapControllers();
app.MapHub<NotificationHub>("/notificationHub");

app.Run();
