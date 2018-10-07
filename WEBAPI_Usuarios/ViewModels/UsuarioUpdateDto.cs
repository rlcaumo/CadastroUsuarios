using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WEBAPI_Usuarios.ViewModels
{
    public class UsuarioUpdateDto
    {
        [Required(ErrorMessage = "O preenchimento do nome é obrigatório...")]
        [MaxLength(100, ErrorMessage = "Nome - O limite é de 100 caracteres.")]
        public string Nome { get; set; }

        [Required(ErrorMessage = "O preenchimento do sobrenome é obrigatório...")]
        [MaxLength(50, ErrorMessage = "Sobrenome - O limite é de 50 caracteres.")]
        public string Sobrenome { get; set; }

        [Required(ErrorMessage = "O preenchimento do email é obrigatório...")]
        [MaxLength(200, ErrorMessage = "Email - O limite é de 200 caracteres.")]
        [EmailAddress]
        public string Email { get; set; }

        [Required(ErrorMessage = "O preenchimento do telefone é obrigatório...")]
        [MaxLength(50, ErrorMessage = "Telefone - O limite é de 50 caracteres.")]
        public string Telefone { get; set; }

        [Required(ErrorMessage = "O preenchimento do endereço é obrigatório...")]
        [MaxLength(200, ErrorMessage = "Endereço - O limite é de 200 caracteres.")]
        public string Endereco { get; set; }
    }
}
