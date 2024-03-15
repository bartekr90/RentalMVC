using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using RentalMVC.Application.Interfaces;
using RentalMVC.Application.Parameters.DeviceService;
using RentalMVC.Application.Parameters.UserDetail;
using RentalMVC.Application.ViewModels.Device;
using System.Security.Claims;

namespace RentalMVC.Web.Controllers;

[Authorize]
public class DeviceController : Controller
{
    private readonly IDeviceService _deviceService;
    private readonly IUserDetailService _userDetailService;
    private readonly UserManager<IdentityUser> _userManager;

    public DeviceController(IDeviceService deviceService,
                            IUserDetailService userDetailService,
                            UserManager<IdentityUser> userManager)
    {
        _deviceService = deviceService;
        _userDetailService = userDetailService;
        _userManager = userManager;
    }

    [HttpGet]
    public async Task<IActionResult> Devices(int? typeId, CancellationToken token = default)
    {
        int rentalId = await GetRentalId(token);

        if (CheckParams(typeId, rentalId))
            return StatusCode(403);

        ListDeviceVm? vm = await _deviceService
            .GetAllDevicesListAsync(new DeviceListParams
            {
                RentalId = rentalId,
                TypeId = typeId!.Value,
                Token = token
            });
        if (vm == null)
            return NotFound();

        return View(vm);
    }

    [HttpGet]
    public async Task<IActionResult> Edit(int? id, CancellationToken token = default)
    {
        int rentalId = await GetRentalId(token);
        if (CheckParams(id, rentalId))
            return StatusCode(403);

        EditDeviceVm? vm = await _deviceService
            .GetDeviceForEditAsync(new DeviceParams
            {
                DeviceId = id!.Value,
                RentalId = rentalId,
                Token = token
            });
        if (vm == null)
            return NotFound();

        return View(vm);
    }

    [HttpPatch]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Edit([FromForm] EditDeviceVm vm, CancellationToken token = default)
    {
        if (vm is null)
            return RedirectToAction(nameof(Devices));

        string userId = await GetUserIdFromDb();
        int rentalId = await GetRentalId(userId, token);

        if (CheckParams(userId, rentalId))
            return StatusCode(403);

        DeviceVm? viewModel = await _deviceService
            .UpdateDeviceAsync(new UpdateDeviceParams
            {
                ViewModel = vm,
                UserId = userId,
                RentalId = rentalId,
                Token = token
            });

        if (viewModel == null)
            return StatusCode(403);

        return View(viewModel);
    }

    [HttpGet]
    public async Task<IActionResult> Create(CancellationToken token = default)
    {
        int rentalId = await GetRentalId(token);
        if (rentalId < 0)
            return StatusCode(403);

        NewDeviceVm? vm = await _deviceService
            .GetNewDeviceAsync(new NewDeviceParams
            {
                RentalId = rentalId,
                Token = token
            });

        if (vm is null)
            return NotFound();

        return View(vm);
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Create([FromForm] NewDeviceVm vm, CancellationToken token = default)
    {
        if (vm is null)
            return RedirectToAction(nameof(Devices));        

        string userId = await GetUserIdFromDb();
        int rentalId = await GetRentalId(userId, token);

        if (CheckParams(userId, rentalId))
            return StatusCode(403);
        vm.UserId = userId;

        DeviceVm? viewModel = await _deviceService
            .AddDeviceAsync(new AddDeviceParams 
            {
                ViewModel = vm,
                RentalId = rentalId,
                Token = token
            });

        if (viewModel is null)
            return StatusCode(403);

        return View(viewModel);
    }

    [HttpGet]
    public async Task<IActionResult> Delete(int? id, CancellationToken token = default)
    {
        int rentalId = await GetRentalId(token);
        if (CheckParams(id, rentalId))
            return StatusCode(403);
      
        DeviceExtendedVm? vm = await _deviceService
            .GetDeviceByIdAsync(new DeviceParams
            {
                DeviceId = id!.Value,
                RentalId = rentalId,
                Token = token
            });

        if (vm is null)
            return NotFound();

        if (vm.IsAvailable is false)
            return StatusCode(403);

        return View(vm);
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Delete([FromForm] DeviceExtendedVm vm, CancellationToken token = default)
    {
        if (vm is null)
            return RedirectToAction(nameof(Devices));

        if (vm.IsAvailable is false)
            return StatusCode(403);

        string userId = await GetUserIdFromDb();
        int rentalId = await GetRentalId(userId, token);
        if (CheckParams(userId, rentalId))
            return StatusCode(403);

        int? result = await _deviceService
            .DeleteDeviceAsync(new DeleteDeviceParams
            {
                RentalId = rentalId,
                Token = token,
                UserId = userId,
                ViewModel = vm
            });

        if (result is null)
            return StatusCode(403);

        return RedirectToAction(nameof(Devices));
    }

    [HttpDelete]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Remove([FromForm] DeviceExtendedVm vm, CancellationToken token = default)
    {
        if (vm is null)
            return RedirectToAction(nameof(Devices));

        string userId = await GetUserIdFromDb();
        int rentalId = await GetRentalId(userId, token);
        if (CheckParams(userId, rentalId))
            return StatusCode(403);

        int? result = await _deviceService
            .RemoveDeviceAsync(new RemoveDeviceParams
            {
                RentalId = rentalId,
                Token = token,
                ViewModel = vm
               
            });

        if (result is null)
            return StatusCode(403);
       
        return RedirectToAction(nameof(Devices));
    }

    private async Task<int> GetRentalId(CancellationToken token)
    {
        Claim? claim = User.FindFirst(ClaimTypes.NameIdentifier);
        if (claim is null)
            return -1;
        string currentUserId = claim.Value;

        return await GetRentalId(currentUserId, token);
    }
    private async Task<string> GetUserIdFromDb()
    {
        var user = await _userManager.GetUserAsync(User);
        if (user is null)
            return "";
        return user.Id;
    }
    private static bool CheckParams(int? id, int rentalId) => 
        id is null || rentalId < 0;
    private static bool CheckParams(string userId, int rentalId) => 
        userId.IsNullOrEmpty() || rentalId < 0;
    private async Task<int> GetRentalId(string currentUserId, CancellationToken token) =>
       await _userDetailService
           .GetRentalIdFromDetails(new UserDetailParams
           {
               CreatorId = currentUserId,
               Token = token
           });
}