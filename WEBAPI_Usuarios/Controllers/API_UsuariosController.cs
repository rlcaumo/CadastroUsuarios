using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WEBAPI_Usuarios.Services;
using WEBAPI_Usuarios.ViewModels;

namespace WEBAPI_Usuarios.Controllers
{
    public class API_UsuariosController : ApiController
    {
        IUsuarioRepository _usuarioRepository;

        public API_UsuariosController(IUsuarioRepository usuarioRepository)
        {
            _usuarioRepository = usuarioRepository;
        }

        [Route("api/usuarios")]
        //public IEnumerable<UsuarioDto> GetUsuarios()
        public HttpResponseMessage GetUsuarios()
        {
            var usuariosEntities = _usuarioRepository.GetUsuarios();
            var results = AutoMapper.Mapper.Map<IEnumerable<UsuarioDto>>(usuariosEntities);
            return Request.CreateResponse(results);
            //return results;
        }

        [Route("api/usuarios/{usuarioId}")]
        public HttpResponseMessage GetUsuario(int usuarioId)
        {
            var usuarioEntity = _usuarioRepository.GetUsuario(usuarioId);
            if (usuarioEntity == null)
            {
                return Request.CreateResponse(HttpStatusCode.NotFound);
            }
            var results = AutoMapper.Mapper.Map<UsuarioDto>(usuarioEntity);
            return Request.CreateResponse(results);
        }

        [Route("api/usuarios")]
        public HttpResponseMessage Post([FromBody] UsuarioCreationDto usuario)
        {
            if (usuario == null)
            {
                return Request.CreateResponse(HttpStatusCode.NotFound);
            }

            if (usuario.Nome == usuario.Sobrenome)
            {
                ModelState.AddModelError("Sobrenome", "O sobrenome informado deverá ser diferente do nome...");
            }

            if (!ModelState.IsValid)
            {
                return Request.CreateResponse(HttpStatusCode.NotFound);
            }

            var finalUsuario = AutoMapper.Mapper.Map<Entities.Usuario>(usuario);
            _usuarioRepository.AddUsuario(finalUsuario);

            if (!_usuarioRepository.Save())
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, "Ocorreu um problema com a sua solicitação...");
            }

            _usuarioRepository.AddDetalheUsuario(finalUsuario.Id, new Entities.DetalheUsuario() { UsuarioId = finalUsuario.Id, Telefone = usuario.Telefone, Endereco = usuario.Endereco });
            if (!_usuarioRepository.Save())
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, "Ocorreu um problema com a sua solicitação...");
            }
            var createUsuarioToReturn = AutoMapper.Mapper.Map<ViewModels.UsuarioDto>(finalUsuario);
            return Request.CreateResponse(HttpStatusCode.Created, createUsuarioToReturn);
        }

        [Route("api/usuarios/{usuarioId}")]
        public HttpResponseMessage Put(int usuarioId, [FromBody] UsuarioUpdateDto usuario)
        {
            if (usuario == null)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest);
            }

            if (usuario.Nome == usuario.Sobrenome)
            {
                ModelState.AddModelError("Sobrenome", "O sobrenome informado deverá ser diferente do nome...");
            }

            if (!ModelState.IsValid)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest);
            }

            if (!_usuarioRepository.UsuarioExiste(usuarioId))
            {
                return Request.CreateResponse(HttpStatusCode.NotFound);
            }

            var usuarioEntity = _usuarioRepository.GetUsuario(usuarioId);
            if (usuarioEntity == null)
            {
                return Request.CreateResponse(HttpStatusCode.NotFound);
            }

            AutoMapper.Mapper.Map(usuario, usuarioEntity);

            if (!_usuarioRepository.Save())
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, "Ocorreu um problema com a sua solicitação...");
            }

            if (!_usuarioRepository.DetalheExiste(usuarioId))
            {
                _usuarioRepository.AddDetalheUsuario(usuarioEntity.Id, new Entities.DetalheUsuario() { UsuarioId = usuarioEntity.Id, Telefone = usuario.Telefone, Endereco = usuario.Endereco });
            } else
            {
                var DetalheEntity = _usuarioRepository.GetDetalhe(usuarioId);
                _usuarioRepository.DeleteDetalhe(DetalheEntity);
                _usuarioRepository.AddDetalheUsuario(usuarioEntity.Id, new Entities.DetalheUsuario() { UsuarioId = usuarioEntity.Id, Telefone = usuario.Telefone, Endereco = usuario.Endereco });
            }

            if (!_usuarioRepository.Save())
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, "Ocorreu um problema com a sua solicitação...");
            }

            return Request.CreateResponse(HttpStatusCode.NoContent);

        }

        [Route("api/usuarios/{usuarioId}")]
        public HttpResponseMessage Delete(int usuarioId)
        {
            var usuarioFromRepo = _usuarioRepository.GetUsuario(usuarioId);
            if (usuarioFromRepo == null)
            {
                return Request.CreateResponse(HttpStatusCode.NotFound);
            }

            if (!_usuarioRepository.DetalheExiste(usuarioId))
            {
                _usuarioRepository.DeleteUsuario(usuarioFromRepo);
            }
            else
            {
                var DetalheEntity = _usuarioRepository.GetDetalhe(usuarioId);
                _usuarioRepository.DeleteDetalhe(DetalheEntity);
                _usuarioRepository.DeleteUsuario(usuarioFromRepo);
            }

            if (!_usuarioRepository.Save())
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, "Ocorreu um problema com a sua solicitação...");
            }

            return Request.CreateResponse(HttpStatusCode.NoContent);
        }

    }
}
