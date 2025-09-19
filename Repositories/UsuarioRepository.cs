using PNLExamGenerator.Models;
using PNLExamGenerator.Data;
using System.Linq;

namespace PNLExamGenerator.Repositories
{
    public class UsuarioRepository : IUsuarioRepository
    {
        private readonly AppDbContext _context;

        public UsuarioRepository(AppDbContext context)
        {
            _context = context;
        }
        public Usuario GetUsuarioByEmail(string email)
        {
           return _context.Usuario.FirstOrDefault(u => u.Email == email);
        }

        public bool Login(string email, string password)
        {
            return _context.Usuario.Any(u => u.Email == email && u.Password == password);
        }

        public void Register(Usuario usuario)
        {
            _context.Usuario.Add(usuario);
            _context.SaveChanges();
        }
    }
}
