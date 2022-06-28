using eCommerce.API.Models;
using eCommerce.API.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

/*
 * CRUD 
 * - GET -> Obter a lista de usuários.
 * - GET -> Onter o usuário passando o ID.
 * - POST -> Cadastrar um usuário.
 * - PUT -> Atualizar um usuário.
 * - DELETE -> Remover um usuário.
 * 
 * 
 * METHOD HTTP: www.minhaapi.com.br/api/Usuarios (todos usuários)
 * www.minhaapi.com.br/api/Usuarios/2 (quando for o usuário especifico)
 */

namespace eCommerce.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsuariosController : ControllerBase
    {
        private IUsuarioRepository _repository;
        public UsuariosController()
        {
            _repository = new UsuarioRepository();
        }

        [HttpGet]
        public IActionResult Get()
        {
            return Ok(_repository.Get()); //HTTP - 200 - OK, se fosse 300 (seria redirecionamento), 400 (error), 500 (erro servidor), etc...
        }

        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var usuario = _repository.Get(id);
            if (usuario == null)
            {
                return NotFound(); //ERRO HTTP: 404
            }

            return Ok(usuario);
        }

        [HttpPost]
        public IActionResult Insert([FromBody]Usuario usuario)
        {
            _repository.Insert(usuario);
            return Ok(usuario);
        }

        [HttpPut]
        public IActionResult Update([FromBody]Usuario usuario)
        {
            _repository.Update(usuario);
            return Ok(usuario);
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            _repository.Delete(id);
            return Ok();
        }

    }
}
