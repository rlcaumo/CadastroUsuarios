using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WEBAPI_Usuarios.Entities;

namespace WEBAPI_Usuarios.Services
{
    public interface IUsuarioRepository
    {
        bool UsuarioExiste(int usuarioId);
        bool DetalheExiste(int usuarioId);
        IEnumerable<Usuario> GetUsuarios();
        Usuario GetUsuario(int usuarioId);
        DetalheUsuario GetDetalhe(int usuarioId);
        void AddUsuario(Usuario usuario);
        void AddDetalheUsuario(int usuarioId, DetalheUsuario detalheUsuario);
        void DeleteUsuario(Usuario usuario);
        void DeleteDetalhe(DetalheUsuario detalhe);
        bool Save();
    }
}
