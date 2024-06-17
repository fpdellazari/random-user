using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RandomUser.Application.Services;
using RandomUser.Domain.DTOs;
using RandomUser.Domain.Services;
using System.ComponentModel;

namespace RandomUser.API.Controllers {
    public class AuthenticationController : Controller {

        public readonly IAuthenticationService _authenticationService;

        public AuthenticationController(IAuthenticationService authenticationService) {
            _authenticationService = authenticationService;
        }

        [HttpPost]
        [Route("api/[controller]/authenticate")]
        public async Task<IActionResult> Authenticate(AuthenticateRequestDTO request) {
            try {
                var token = await _authenticationService.Authenticate(request);
                if (token == "") { 
                    return Unauthorized(); 
                }
                return Ok(new { token = token });
            } catch (Exception e) {
                return BadRequest(e.Message);
            }
        }
    }
}
