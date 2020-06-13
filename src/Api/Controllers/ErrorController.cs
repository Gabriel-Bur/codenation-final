using Application.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class ErrorController : ControllerBase
    {
        private readonly IErrorAppService _errorAppService;
        public ErrorController(IErrorAppService errorAppService)
        {
            _errorAppService = errorAppService ??
                throw new ArgumentNullException(nameof(errorAppService));
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var errors = await _errorAppService.GetErrors();

            return Ok(errors);
        }
    }
}