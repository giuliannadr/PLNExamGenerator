using PNLExamGenerator.Models;

namespace PNLExamGenerator.Repositories
{
    public interface IUsuarioRepository
    {
        bool Login(string email, string password);
        void Register(Usuario usuario);
        Usuario GetUsuarioByEmail(string email);
    }
}
