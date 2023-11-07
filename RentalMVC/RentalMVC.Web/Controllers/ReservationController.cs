using FluentValidation;
using FluentValidation.AspNetCore;
using Microsoft.AspNetCore.Mvc;
using RentalMVC.Application.Interfaces;
using RentalMVC.Application.ViewModels.Reservation;

namespace RentalMVC.Web.Controllers;

public class ReservationController : Controller
{
    private readonly IReservationService _reservationService;
    private readonly IValidator<NewReservationVm> _newReservationValidator;
    public ReservationController(IReservationService reservationService,
                                 IValidator<NewReservationVm> newReservationValidator)
    {

        _reservationService = reservationService;
        _newReservationValidator = newReservationValidator;
    }
    [HttpGet]
    public async Task<IActionResult> Index(CancellationToken token = default)
    {
        ListReservationVm model = await _reservationService.GetActiveReservationsVmAsync(token);

        return View(model);
    }

    // GET: ReservationController/Details/5
    [HttpGet]
    public IActionResult Create()
    {        

        NewReservationVm model = _reservationService.GetNewReservationVm();

        return View(model);
    }

    // POST: ReservationController/Create
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Create([FromForm] NewReservationVm viewModel, CancellationToken token = default)
    {
        var validateResult = _newReservationValidator.Validate(viewModel);

        if (!validateResult.IsValid)
        {          
            validateResult.AddToModelState(this.ModelState);
            return View(viewModel);
        }        
        int result = await _reservationService.AddReservationAsync(viewModel, token);
        TempData["notice"] = "Person successfully created";

        return RedirectToAction(nameof(Index));
    }

    // GET: ReservationController/Edit/5
    [HttpGet]
    public IActionResult Edit(int id)
    {
        return View();
    }

    // POST: ReservationController/Edit/5
    [HttpPost]
    [ValidateAntiForgeryToken]
    public IActionResult Edit(int id, IFormCollection collection)
    {
        try
        {
            return RedirectToAction(nameof(Index));
        }
        catch
        {
            return View();
        }
    }

    // GET: ReservationController/Delete/5
    public IActionResult Delete(int id)
    {
        return View();
    }

    // POST: ReservationController/Delete/5
    [HttpPost]
    [ValidateAntiForgeryToken]
    public ActionResult Delete(int id, IFormCollection collection)
    {
        try
        {
            return RedirectToAction(nameof(Index));
        }
        catch
        {
            return View();
        }
    }
}
