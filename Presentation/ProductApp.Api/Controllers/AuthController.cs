using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using ProductApp.Application.Features.Auth.Command.Login;
using ProductApp.Application.Features.Auth.Command.RefreshToken;
using ProductApp.Application.Features.Auth.Command.Register;

namespace ProductApp.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]/[action]")]
    public class AuthController : ControllerBase
    {
        private readonly IMediator mediator;

        public AuthController(IMediator mediator)
        {
            this.mediator = mediator;
        }

        [HttpPost]
        public async Task<IActionResult> Register(RegisterCommandRequest request)
        {
            await mediator.Send(request);
            return StatusCode(StatusCodes.Status201Created);
        }

        [HttpPost]
        public async Task<IActionResult> Login(LoginCommandRequest request)
        {
            var response = await mediator.Send(request);
            return StatusCode(StatusCodes.Status200OK,response);
        }
        [HttpPost]
        public async Task<IActionResult> RefreshToken(RefreshTokenCommandRequest request)
        {
            var response = await mediator.Send(request);
            return StatusCode(StatusCodes.Status200OK,response);
        }
    }
}