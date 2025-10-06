﻿using Application.Interfaces.AuthInterface;
using Application.Models.UserModel;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace AuthServiceApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IAuthService _authService;

        public AuthController(IAuthService authService)
        {
            _authService = authService;
        }

        // POST: api/auth/register
        [HttpPost("register")]
        public async Task<IActionResult> Register([FromBody] UserDTO user)
        {
            var result = await _authService.Register(user);
            return new JsonResult(result);
        }

        // Get: api/auth/login
        [HttpGet("login")]
        public async Task<IActionResult> Login([FromBody] LoginUserDTO login)
        {
            var result = await _authService.Login(login);
            return new JsonResult(result);
        }

        // GET: api/auth/me
        [HttpGet("me")]
        [Authorize]
        public async Task<IActionResult> GetCurrentUser()
        {
            var userIdClaim = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;

            if (string.IsNullOrEmpty(userIdClaim))
                return Unauthorized("Invalid token — no user ID found.");

            var userId = Guid.Parse(userIdClaim);

            var result = await _authService.GetCurrentUser(userId);
            return Ok(result);
        }
    }
}

