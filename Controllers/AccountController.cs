using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using PNLExamGenerator.Models; 
using PNLExamGenerator.Services;
using PLNExamGenerator.Entidades;

namespace PNLExamGenerator.Controllers
{
    public class AccountController : Controller
    {
        private readonly ILogger<AccountController> _logger;
        private readonly IUsuarioService _usuarioService;



        public AccountController(ILogger<AccountController> logger, IUsuarioService usuarioService)
        {
            _logger = logger;
            _usuarioService = usuarioService;
        }

        [HttpPost]
       // [ValidateAntiForgeryToken]
        public IActionResult Login(string email, string pass)
        {
            // Simulando validación
            bool exito = _usuarioService.Login(email,pass);

            if (exito)
            {
                var usuario = _usuarioService.GetUsuarioByEmail(email);
                HttpContext.Session.SetString("NombreUsuario", usuario.Nombre);
                return Json(new { success = true, mensaje = "Bienvenido", nombre = usuario.Nombre });
            }
            else
            {
                return Json(new { success = false, mensaje = "Email o contraseña incorrecta" });
            }
        }

        [HttpPost]
       // [ValidateAntiForgeryToken]
        public IActionResult Register(string name, string email, string pass, string confirmPass)
        {
            try
            {
                if (pass != confirmPass)
                    return Json(new { success = false, mensaje = "Las contraseñas no coinciden" });

                _usuarioService.Register(new Usuario { Nombre = name, Email = email, Password = pass });
                HttpContext.Session.SetString("NombreUsuario", name);

                return Json(new { success = true, mensaje = $"Usuario {name} registrado", nombre = name });
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error en Register");
                return Json(new { success = false, mensaje = "Ocurrió un error al registrarse" });
            }
        
    }

    }

}
