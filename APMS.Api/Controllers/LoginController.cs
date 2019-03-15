using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using APMS.BusinessLogic.Dto;
using APMS.BusinessLogic.Exceptions;
using APMS.BusinessLogic.ViewModels.User;
using APMS.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace APMS.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        private readonly ILoginService _loginService;
        private readonly ILogger<LoginController> _logger;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="loginService"></param>
        /// <param name="logger"></param>
        public LoginController(ILoginService loginService, ILogger<LoginController> logger)
        {
            _loginService = loginService;
            _logger = logger;
        }

        /// <summary>
        ///     Login user
        /// </summary>
        /// <param name="viewModel"><see cref="LoginViewModel"/></param>
        /// <response code="200">Returns user token</response>
        /// <response code="400">If the request is invalid</response>  
        /// <response code="401">If the credentials are invalid</response>
        /// <response code="500">If a server error occured</response>
        [HttpPost]
        [Route("")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> Login([FromBody] LoginViewModel viewModel)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                var result = await _loginService.LoginAsync(viewModel);

                // TODO: Jwt
                if (result != null)
                {
                    return Ok(result);
                }

                return new StatusCodeResult(StatusCodes.Status500InternalServerError);
            }
            catch(InvalidCredentialsException)
            {
                return new StatusCodeResult(StatusCodes.Status401Unauthorized);
            }
        }
    }
}