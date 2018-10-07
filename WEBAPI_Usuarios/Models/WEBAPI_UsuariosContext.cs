using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using WEBAPI_Usuarios.Entities;

namespace WEBAPI_Usuarios.Models
{
    public class WEBAPI_UsuariosContext : DbContext
    {
        // You can add custom code to this file. Changes will not be overwritten.
        // 
        // If you want Entity Framework to drop and regenerate your database
        // automatically whenever you change your model schema, please use data migrations.
        // For more information refer to the documentation:
        // http://msdn.microsoft.com/en-us/data/jj591621.aspx
    
        public WEBAPI_UsuariosContext() : base("name=WEBAPI_UsuariosContext")
        {
        }

        public DbSet<Usuario> Usuarios { get; set; }

        public DbSet<DetalheUsuario> Detalhe_Usuarios { get; set; }
    }
}
