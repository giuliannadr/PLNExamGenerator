﻿
using PLNExamGenerator.Entidades;
using Microsoft.EntityFrameworkCore;
using PNLExamGenerator.Data;

namespace PLNExamGenerator.Logica
{
    public interface IUsuarioLogica
    {
        Usuario GetUsuarioByEmail(string email);
        bool Login(string email, string password);
        void Register(Usuario usuario);
    }

    public class UsuarioLogica : IUsuarioLogica
    {
        private readonly PLNExamGeneratorContext _context;

        public UsuarioLogica(PLNExamGeneratorContext context)
        {
            _context = context;
        }

        public Usuario GetUsuarioByEmail(string email)
        {
            return _context.Usuario.FirstOrDefault(u => u.Email == email);
        }

        public bool Login(string email, string password)
        {
            var usuario = _context.Usuario.FirstOrDefault(u => u.Email == email);
            if (usuario == null) return false;

            // 🔒 En un proyecto real deberías encriptar/verificar el hash de la contraseña
            return usuario.Password == password;
        }

        public void Register(Usuario usuario)
        {
            if (_context.Usuario.Any(u => u.Email == usuario.Email))
                throw new Exception("El email ya está registrado");

            _context.Usuario.Add(usuario);
            _context.SaveChanges();
        }
    }
}

