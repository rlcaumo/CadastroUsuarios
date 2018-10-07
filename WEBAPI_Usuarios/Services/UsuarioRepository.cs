using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WEBAPI_Usuarios.Entities;
using WEBAPI_Usuarios.Models;

namespace WEBAPI_Usuarios.Services
{
    public class UsuarioRepository : IUsuarioRepository
    {
        private WEBAPI_UsuariosContext _context;
        public UsuarioRepository(WEBAPI_UsuariosContext context)
        {
            this._context = context;
        }

        public bool UsuarioExiste(int usuarioId)
        {
            return _context.Usuarios.Any(c => c.Id == usuarioId);
        }

        public bool DetalheExiste(int usuarioId)
        {
            return _context.Detalhe_Usuarios.Any(c => c.UsuarioId == usuarioId);
        }

        public IEnumerable<Usuario> GetUsuarios()
        {
            return _context.Usuarios.OrderBy(c => c.Nome).ToList();
        }

        public Usuario GetUsuario(int usuarioId)
        {
            return _context.Usuarios.Where(c => c.Id == usuarioId).FirstOrDefault();
        }

        public DetalheUsuario GetDetalhe(int usuarioId)
        {
            return _context.Detalhe_Usuarios.Where(c => c.UsuarioId == usuarioId).FirstOrDefault();
        }

        public void AddUsuario(Usuario usuario)
        {
            _context.Usuarios.Add(usuario);
        }

        public void AddDetalheUsuario(int usuarioId, DetalheUsuario detalheUsuario)
        {
            _context.Detalhe_Usuarios.Add(detalheUsuario);
            //var usuario = GetUsuario(usuarioId);
            //usuario.Detalhe = detalheUsuario;
//////            usuario.Detalhe.Add(detalheUsuario);
        }

        public void DeleteUsuario(Usuario usuario)
        {
            _context.Usuarios.Remove(usuario);
        }

        public void DeleteDetalhe(DetalheUsuario detalhe)
        {
            _context.Detalhe_Usuarios.Remove(detalhe);
        }

        //void DeleteDetalhe(Usuario usuario);

        public bool Save()
        {
            return (_context.SaveChanges() >= 0);
        }
    }
}
