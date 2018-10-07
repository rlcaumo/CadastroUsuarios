using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WEBAPI_Usuarios.Entities;

namespace WEBAPI_Usuarios.ViewModels
{ 
    public class UsuarioDto
    {
        public string Id { get; set; }
        public string Nome { get; set; }
        public string Sobrenome { get; set; }
        public string Email { get; set; }
        public virtual DetalheUsuarioDto Detalhe { get; set; }
    }
}
