using Microsoft.EntityFrameworkCore;
using PredictiveMaintenance.Domain.Entities;

namespace PredictiveMaintenance.Infrastructure.Data;

public static class DataSeeder
{
    public static async Task SeedAsync(ApplicationDbContext context)
    {
        // Check if data already exists
        if (await context.Equipments.AnyAsync())
            return;

        // Create demo equipments
        var equipments = new List<Equipment>
        {
            new Equipment { Name = "Pompa A-101", Type = "Pompa", Location = "Üretim Hattı 1", Status = "Normal", CreatedAt = DateTime.UtcNow },
            new Equipment { Name = "Motor B-202", Type = "Motor", Location = "Üretim Hattı 2", Status = "Normal", CreatedAt = DateTime.UtcNow },
            new Equipment { Name = "Vana C-303", Type = "Vana", Location = "Depo Alanı", Status = "Normal", CreatedAt = DateTime.UtcNow },
            new Equipment { Name = "Basınç Sensörü D-404", Type = "Sensör", Location = "Kontrol Odası", Status = "Normal", CreatedAt = DateTime.UtcNow },
            new Equipment { Name = "Kompresör E-505", Type = "Kompresör", Location = "Üretim Hattı 3", Status = "Uyarı", CreatedAt = DateTime.UtcNow }
        };

        context.Equipments.AddRange(equipments);
        await context.SaveChangesAsync();

        // Create demo sensor data for last 24 hours
        var random = new Random();
        var sensorTypes = new[] { "Temperature", "Pressure", "Vibration", "Current" };
        var now = DateTime.UtcNow;

        foreach (var equipment in equipments)
        {
            var sensorDataList = new List<SensorData>();

            // Generate data for last 24 hours (hourly)
            for (int i = 24; i >= 0; i--)
            {
                var timestamp = now.AddHours(-i);

                foreach (var sensorType in sensorTypes)
                {
                    // Generate realistic values with some anomalies
                    double value = sensorType switch
                    {
                        "Temperature" => random.NextDouble() * 50 + 20, // 20-70°C
                        "Pressure" => random.NextDouble() * 100 + 50,   // 50-150 PSI
                        "Vibration" => random.NextDouble() * 10 + 1,    // 1-11 mm/s
                        "Current" => random.NextDouble() * 20 + 5,      // 5-25 A
                        _ => random.NextDouble() * 100
                    };

                    // Add some anomalies (10% chance)
                    if (random.NextDouble() < 0.1)
                    {
                        value *= 1.5; // Increase value for anomaly
                    }

                    sensorDataList.Add(new SensorData
                    {
                        EquipmentId = equipment.Id,
                        SensorType = sensorType,
                        Value = value,
                        Unit = sensorType switch
                        {
                            "Temperature" => "Celsius",
                            "Pressure" => "PSI",
                            "Vibration" => "mm/s",
                            "Current" => "Ampere",
                            _ => "Unit"
                        },
                        Timestamp = timestamp,
                        IsAnomaly = random.NextDouble() < 0.1
                    });
                }
            }

            context.SensorData.AddRange(sensorDataList);
        }

        await context.SaveChangesAsync();

        // Create demo predictions (some critical)
        var predictions = new List<MaintenancePrediction>
        {
            new MaintenancePrediction
            {
                EquipmentId = equipments[0].Id,
                PredictionType = "LSTM",
                FailureProbability = 15.5,
                PredictedDate = now.AddDays(30),
                Status = "Normal",
                RecommendedAction = "Rutin bakım önerilir",
                CreatedAt = now
            },
            new MaintenancePrediction
            {
                EquipmentId = equipments[4].Id, // Kompresör (Uyarı durumu)
                PredictionType = "LSTM",
                FailureProbability = 75.8,
                PredictedDate = now.AddDays(5),
                Status = "Critical",
                RecommendedAction = "Acil bakım gerekli!",
                CreatedAt = now
            },
            new MaintenancePrediction
            {
                EquipmentId = equipments[1].Id,
                PredictionType = "Random Forest",
                FailureProbability = 45.2,
                PredictedDate = now.AddDays(15),
                Status = "Warning",
                RecommendedAction = "Yakın zamanda bakım planlanmalı",
                CreatedAt = now
            }
        };

        context.MaintenancePredictions.AddRange(predictions);
        await context.SaveChangesAsync();

        // Create demo alerts
        var alerts = new List<Alert>
        {
            new Alert
            {
                EquipmentId = equipments[4].Id,
                AlertType = "High Failure Probability",
                Message = "Kompresör E-505 için yüksek arıza olasılığı tespit edildi (%75.8)",
                Severity = "Critical",
                IsRead = false,
                CreatedAt = now
            },
            new Alert
            {
                EquipmentId = equipments[1].Id,
                AlertType = "Anomaly Detected",
                Message = "Motor B-202'de anomali tespit edildi",
                Severity = "Medium",
                IsRead = false,
                CreatedAt = now.AddHours(-2)
            },
            new Alert
            {
                EquipmentId = equipments[0].Id,
                AlertType = "Maintenance Due",
                Message = "Pompa A-101 için bakım zamanı yaklaşıyor",
                Severity = "Low",
                IsRead = false,
                CreatedAt = now.AddHours(-5)
            }
        };

        context.Alerts.AddRange(alerts);
        await context.SaveChangesAsync();

        // Create demo maintenance history
        var maintenanceHistory = new List<MaintenanceHistory>
        {
            new MaintenanceHistory
            {
                EquipmentId = equipments[0].Id,
                MaintenanceType = "Preventive",
                MaintenanceDate = now.AddDays(-30),
                Description = "Rutin bakım yapıldı",
                Technician = "Ahmet Yılmaz",
                Cost = 5000.00
            },
            new MaintenanceHistory
            {
                EquipmentId = equipments[1].Id,
                MaintenanceType = "Corrective",
                MaintenanceDate = now.AddDays(-60),
                Description = "Arıza giderildi",
                Technician = "Mehmet Demir",
                Cost = 15000.00
            }
        };

        context.MaintenanceHistories.AddRange(maintenanceHistory);
        await context.SaveChangesAsync();
    }
}
