using Microsoft.AspNetCore.Mvc;
using SearchingForItems.Models;
using SearchingForItems.Services;

namespace SearchingForItems.Controllers
{
    public class AccountController : Controller
    {
        private readonly ApiService? api;

        public AccountController(ApiService? api)
        {
            this.api = api;
        }

        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(Login model)
        {
            var response = await api.Login(model.Email, model.Password);
            string userId = response?.userId ?? "";

            // Сохраняем в сессию
            HttpContext.Session.SetString("UserId", userId);

            return RedirectToAction("Index", "Home");
        }
    }
}
