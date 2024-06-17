using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using RandomUser.Domain.Services;

namespace RandomUser.API.Controllers {

    [ApiController]
    public class RandomUserController : Controller {

        public readonly IGenerateUserService _generateUserService;
        public readonly IUserService _userService;

        public RandomUserController(IGenerateUserService generateUserService, IUserService userService) {
            _generateUserService = generateUserService;
            _userService = userService;
        }

        [HttpGet]
        [Route("api/[controller]/get")]
        [Authorize]
        public ActionResult Get() {
            try {
                var users = _userService.Get();
                return Ok(users);
            } catch (Exception e) {
                return BadRequest(e.Message);
            }
        }

        [HttpPost]
        [Route("api/[controller]/generateuser")]
        [Authorize]
        public async Task<IActionResult> GenerateUser() {
            try {
                await _generateUserService.GenerateUser();
            } catch (Exception e) {
                return BadRequest(e.Message);
            }
            return Ok();
        }
    }
}
