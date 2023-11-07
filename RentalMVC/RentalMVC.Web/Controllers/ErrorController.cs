using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using RentalMVC.Web.Models;
using System.Diagnostics;

namespace RentalMVC.Web.Controllers;

public class ErrorController : Controller
{
    private readonly ILogger<ErrorController> _logger;

    public ErrorController(ILogger<ErrorController> logger)
    {
        _logger = logger;
    }

    [Route("Error/{statusCode}")]
    public IActionResult HttpStatusCodeHandler(int statusCode)
    {        
        ViewBag.ErrorMessage = statusCode switch
        {
            400 => "Bad Request: The server could not understand the request due to invalid syntax",
            401 => "Unauthorized Error: The request requires user authentication",
            403 => "Forbidden: The server understood the request, but is refusing to fulfill it",
            404 => "Not Found: The server has not found anything matching the Request-URI",
            500 => "Internal Server Error: The server encountered an unexpected condition that prevented it from fulfilling the request",
            501 => "Not Implemented: The server doesn’t recognize the request method or doesn’t have the ability to fulfill it",
            502 => "Bad Gateway: This error occurs when a server acting as a gateway or proxy receives an invalid response from an upstream server",
            503 => "Service Unavailable: This means that the server is currently unable to handle the request due to a temporary overload or scheduled maintenance",
            504 => "Gateway Timeout: This error occurs when a server did not receive a timely response from another server that it was accessing while attempting to load the web page or fill another request by the browser",
            505 => "HTTP Version Not Supported: This error occurs when the server does not support the HTTP protocol version used in the request",
            _ => "An error occurred"
        };

        return View();
    }

    [AllowAnonymous]
    [Route("Error")]
    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        var exceptionHandler = HttpContext.Features.Get<IExceptionHandlerPathFeature>();
        ArgumentNullException.ThrowIfNull(exceptionHandler);

        var model = new ErrorViewModel
        {
            RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier,
            ExceptionPath = exceptionHandler.Path,
            ExceptionMessage = exceptionHandler.Error.Message
        };
        return View(model);
    }
}
