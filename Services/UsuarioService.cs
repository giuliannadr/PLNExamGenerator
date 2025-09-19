using PNLExamGenerator.Models;
using PNLExamGenerator.Repositories;

namespace PNLExamGenerator.Services
{
    public class UsuarioService : IUsuarioService
    {
        private readonly IUsuarioRepository _usuarioRepository;
        public UsuarioService(IUsuarioRepository usuarioRepository)
        {
            _usuarioRepository = usuarioRepository;
        }

        public Usuario GetUsuarioByEmail(string email)
        {
            return _usuarioRepository.GetUsuarioByEmail(email);
        }

        public bool Login(string email, string password)
        {
            return _usuarioRepository.Login(email, password);
        }

        public void Register(Usuario usuario)
        {
            if (_usuarioRepository.GetUsuarioByEmail(usuario.Email) != null)
            {
                throw new Exception("El email ya está registrado");
            }
            _usuarioRepository.Register(usuario);
        }
    }
}
