using Microsoft.AspNetCore.Mvc;
using RandomUser.Domain.Services;

namespace RandomUser.API.Controllers {

    [ApiController]
    public class RandomUserController : Controller {

        public readonly IGenerateUserService _generateUserService;

        public RandomUserController(IGenerateUserService generateUserService) {
            _generateUserService = generateUserService;
        }

        [HttpPost]
        [Route("api/[controller]/generateuser")]
        [Consumes("application/json")]
        public IActionResult GenerateUser() {
            try {
                _generateUserService.GenerateUser();
            } catch (Exception e) {
                return BadRequest(e.Message);
            }
            return Ok();
        }
    }
}
