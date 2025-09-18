using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using PNLExamGenerator.Models; // tus modelos (por ejemplo Usuario)


namespace PNLExamGenerator.Controllers
{
    public class AccountController : Controller
    {
        private readonly ILogger<AccountController> _logger;

        public AccountController(ILogger<AccountController> logger)
        {
            _logger = logger;
        }

        [HttpPost]
        public IActionResult Login(string email, string pass)
        {
            // Simulando validación
            bool exito = (email == "test@test.com" && pass == "1234");

            if (exito)
            {
                // Aquí podrías iniciar sesión con cookies o claims
                return Json(new { success = true, mensaje = "Bienvenido" });
            }
            else
            {
                return Json(new { success = false, mensaje = "Email o contraseña incorrecta" });
            }
        }

        [HttpPost]
        public IActionResult Register(string name, string email, string pass, string confirmPass)
        {
            if (pass != confirmPass)
                return Json(new { success = false, mensaje = "Las contraseñas no coinciden" });

            // Aquí podrías guardar el usuario en DB

            return Json(new { success = true, mensaje = $"Usuario {name} registrado" });
        }

    }

}
