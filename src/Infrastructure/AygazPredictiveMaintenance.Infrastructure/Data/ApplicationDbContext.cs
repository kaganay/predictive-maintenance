using Microsoft.EntityFrameworkCore;
using PredictiveMaintenance.Domain.Entities;

namespace PredictiveMaintenance.Infrastructure.Data;

public class ApplicationDbContext : DbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
    {
    }

    public DbSet<Equipment> Equipments { get; set; }
    public DbSet<SensorData> SensorData { get; set; }
    public DbSet<MaintenancePrediction> MaintenancePredictions { get; set; }
    public DbSet<Alert> Alerts { get; set; }
    public DbSet<MaintenanceHistory> MaintenanceHistories { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        // Equipment Configuration
        modelBuilder.Entity<Equipment>(entity =>
        {
            entity.HasKey(e => e.Id);
            entity.Property(e => e.Name).IsRequired().HasMaxLength(200);
            entity.Property(e => e.Type).IsRequired().HasMaxLength(100);
            entity.Property(e => e.Location).IsRequired().HasMaxLength(200);
            entity.Property(e => e.Status).IsRequired().HasMaxLength(50);
            entity.HasIndex(e => e.Status);
        });

        // SensorData Configuration
        modelBuilder.Entity<SensorData>(entity =>
        {
            entity.HasKey(e => e.Id);
            entity.Property(e => e.SensorType).IsRequired().HasMaxLength(100);
            entity.Property(e => e.Value).IsRequired();
            entity.Property(e => e.Unit).HasMaxLength(50);
            entity.HasIndex(e => e.EquipmentId);
            entity.HasIndex(e => e.Timestamp);
            entity.HasOne(e => e.Equipment)
                  .WithMany(eq => eq.SensorData)
                  .HasForeignKey(e => e.EquipmentId)
                  .OnDelete(DeleteBehavior.Cascade);
        });

        // MaintenancePrediction Configuration
        modelBuilder.Entity<MaintenancePrediction>(entity =>
        {
            entity.HasKey(e => e.Id);
            entity.Property(e => e.PredictionType).IsRequired().HasMaxLength(100);
            entity.Property(e => e.Status).IsRequired().HasMaxLength(50);
            entity.Property(e => e.RecommendedAction).HasMaxLength(500);
            entity.HasIndex(e => e.EquipmentId);
            entity.HasIndex(e => e.Status);
            entity.HasOne(e => e.Equipment)
                  .WithMany(eq => eq.MaintenancePredictions)
                  .HasForeignKey(e => e.EquipmentId)
                  .OnDelete(DeleteBehavior.Cascade);
        });

        // Alert Configuration
        modelBuilder.Entity<Alert>(entity =>
        {
            entity.HasKey(e => e.Id);
            entity.Property(e => e.AlertType).IsRequired().HasMaxLength(100);
            entity.Property(e => e.Message).IsRequired().HasMaxLength(1000);
            entity.Property(e => e.Severity).IsRequired().HasMaxLength(50);
            entity.HasIndex(e => e.EquipmentId);
            entity.HasIndex(e => e.IsRead);
            entity.HasOne(e => e.Equipment)
                  .WithMany(eq => eq.Alerts)
                  .HasForeignKey(e => e.EquipmentId)
                  .OnDelete(DeleteBehavior.Cascade);
        });

        // MaintenanceHistory Configuration
        modelBuilder.Entity<MaintenanceHistory>(entity =>
        {
            entity.HasKey(e => e.Id);
            entity.Property(e => e.MaintenanceType).IsRequired().HasMaxLength(100);
            entity.Property(e => e.Description).IsRequired().HasMaxLength(1000);
            entity.Property(e => e.Technician).IsRequired().HasMaxLength(200);
            entity.HasIndex(e => e.EquipmentId);
            entity.HasIndex(e => e.MaintenanceDate);
            entity.HasOne(e => e.Equipment)
                  .WithMany(eq => eq.MaintenanceHistories)
                  .HasForeignKey(e => e.EquipmentId)
                  .OnDelete(DeleteBehavior.Cascade);
        });
    }
}
