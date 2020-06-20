using Application.Interfaces;
using Application.ViewModels.Request;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ErrorController : ControllerBase
    {
        private readonly IErrorAppService _errorAppService;
        public ErrorController(IErrorAppService errorAppService)
        {
            _errorAppService = errorAppService ??
                throw new ArgumentNullException(nameof(errorAppService));
        }

        [Authorize]
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var errors = await _errorAppService.GetErrors();

            return Ok(errors);
        }

        [Authorize]
        [HttpPost]
        public async Task<IActionResult> Add(ErrorRequest errorRequest)
        {
            await _errorAppService.AddError(errorRequest);

            return Ok();
        }
    }
}