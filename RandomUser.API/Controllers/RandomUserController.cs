using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;

namespace RandomUser.API.Controllers {

    [ApiController]
    public class RandomUserController : Controller {

        public RandomUserController() {
        }

        [HttpPost]
        [Route("api/[controller]/generateuser")]
        [Consumes("application/json")]
        public IActionResult GenerateUser() {
            try {
            } catch (Exception e) {
                return BadRequest(e.Message);
            }
            return Ok();
        }
    }
}
