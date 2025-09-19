using PNLExamGenerator.Models;

namespace PNLExamGenerator.Services
{
    public interface IUsuarioService
    {
        bool Login(string email, string password);
        void Register(Usuario usuario);
        Usuario GetUsuarioByEmail(string email);
    }
}
