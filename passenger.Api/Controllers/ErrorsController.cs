using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Mvc;

namespace passenger.Api.Controllers
{
    [ApiExplorerSettings(IgnoreApi = true)]

    public class ErrorsController : Controller
    {
        private readonly ILogger<ErrorsController> _logger;

        public ErrorsController(ILogger<ErrorsController> logger)
        {
            _logger = logger;
        }

        [Route("/error-development")]
        public IActionResult HandleErrorDevelopment(
            [FromServices] IHostEnvironment hostEnvironment)
        {
            if (!hostEnvironment.IsDevelopment())
            {
                return NotFound();
            }

            var exceptionHandlderFeature = HttpContext.Features.Get<IExceptionHandlerFeature>()!;

            _logger.LogError(exceptionHandlderFeature.Error, "Unhandled Exception");

            return Problem(
                detail: exceptionHandlderFeature.Error.StackTrace,
                title: exceptionHandlderFeature.Error.Message);
        }

        public IActionResult HandleError()
        {
            var exceptionHandlderFeature = HttpContext.Features.Get<IExceptionHandlerFeature>()!;
            _logger.LogError(exceptionHandlderFeature.Error, "Unhandled Exception");

            return Problem();
        }
    }
}
