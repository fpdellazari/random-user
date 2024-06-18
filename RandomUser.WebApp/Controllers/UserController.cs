using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RandomUser.Domain.Services;

namespace RandomUser.WebApp.Controllers {
    public class UserController : Controller {

        public readonly IUserService _userService;

        public UserController(IUserService userService) {
            _userService = userService;
        }

        public ActionResult Index() {
            var user = _userService.Get();
            return View(user);
        }

        public ActionResult Details(int id) {
            var user = _userService.Get(id);
            return View(user);
        }

        public ActionResult Edit(int id) {
            var user = _userService.Get(id);
            return View(user);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Domain.Entities.User user) {
            try {
                _userService.Update(user);
                return RedirectToAction(nameof(Index));
            } catch {
                return View(user);
            }
        }
    }
}
