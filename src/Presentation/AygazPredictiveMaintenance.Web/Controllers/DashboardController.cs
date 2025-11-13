using Microsoft.AspNetCore.Mvc;
using PredictiveMaintenance.Application.Services;

namespace PredictiveMaintenance.Web.Controllers;

public class DashboardController : Controller
{
    private readonly IEquipmentService _equipmentService;
    private readonly IPredictionService _predictionService;
    private readonly IAlertService _alertService;

    public DashboardController(
        IEquipmentService equipmentService,
        IPredictionService predictionService,
        IAlertService alertService)
    {
        _equipmentService = equipmentService;
        _predictionService = predictionService;
        _alertService = alertService;
    }

    public async Task<IActionResult> Index()
    {
        var equipments = await _equipmentService.GetAllAsync();
        var criticalPredictions = await _predictionService.GetCriticalPredictionsAsync();
        var unreadAlerts = await _alertService.GetUnreadAlertsAsync();

        ViewBag.Equipments = equipments;
        ViewBag.CriticalPredictions = criticalPredictions;
        ViewBag.UnreadAlerts = unreadAlerts;

        return View();
    }
}


