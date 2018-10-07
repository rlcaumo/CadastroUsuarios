using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using WEBAPI_Usuarios.Entities;

namespace WEBAPI_Usuarios.Models
{
    public class WEBAPI_ContextInitializer : DropCreateDatabaseAlways<WEBAPI_UsuariosContext>
    {
        protected override void Seed(WEBAPI_UsuariosContext context)
        {
            var usuarios = new List<Usuario>
            {
                new Usuario(){Nome="Reginaldo", Sobrenome="Caumo",Email="rlcaumo@gmail.com",Detalhe=null},
                new Usuario(){Nome="Maria Regina", Sobrenome="Santos",Email="mrsantos@gmail.com",Detalhe=null}
            };
            usuarios.ForEach(b => context.Usuarios.Add(b));
            context.SaveChanges();

            var detalhe1 = new DetalheUsuario() { UsuarioId = 1, Telefone = "11-99993-5449", Endereco = "Rua Paracatu, 3002", Usuario = usuarios[0] };
            context.Detalhe_Usuarios.Add(detalhe1);

            base.Seed(context);
        }
    }
}