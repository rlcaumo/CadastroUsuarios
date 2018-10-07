using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace WEBAPI_Usuarios.Entities
{
    public class DetalheUsuario
    {
        [Key]
        [ForeignKey("Usuario")]
        public int UsuarioId { get; set; }

        [Required]
        [MaxLength(50)]
        public string Telefone { get; set; }

        [Required]
        [MaxLength(200)]
        public string Endereco { get; set; }

        public virtual Usuario Usuario { get; set; }
    }
}