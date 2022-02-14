using CadastroUsuario.Data;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CadastroUsuario.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsuariosController : ControllerBase
    {
        private readonly DataContext _context;

        public UsuariosController(DataContext context)
        {
            _context = context;
        }


        [HttpGet]
        public async Task<ActionResult<List<Usuario>>> Get()
        {
            return Ok(await _context.Usuarios.ToListAsync());
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Usuario>> Get(int id)
        {
            var dbusuario = await _context.Usuarios.FindAsync(id);
            if (dbusuario == null)
                return BadRequest("Usuário não encontrado.");
            return Ok(await _context.Usuarios.ToListAsync());

        }

        [HttpPost]
        public async Task<ActionResult<List<Usuario>>> AddUsuario(Usuario usuario)
        {
            _context.Usuarios.Add(usuario);
            await _context.SaveChangesAsync();
            return Ok(await _context.Usuarios.ToListAsync());
        }

        [HttpPut]
        public async Task<ActionResult<List<Usuario>>> UpdateUsuario(Usuario request)
        {
            var dbusuario = await _context.Usuarios.FindAsync(request.Id);
            if (dbusuario == null)
                return BadRequest("Usuário não encontrado.");

            dbusuario.NomeCompleto = request.NomeCompleto;
            dbusuario.Email = request.Email;
            dbusuario.Cidade = request.Cidade;
            dbusuario.CEP = request.CEP;

            await _context.SaveChangesAsync();
            return Ok(await _context.Usuarios.ToListAsync());
        }


        [HttpDelete("{id}")]
        public async Task<ActionResult<List<Usuario>>> Delete(int id)
        {
            var dbusuario = await _context.Usuarios.FindAsync(id);
            if (dbusuario == null)
                return BadRequest("Usuário não encontrado.");
            _context.Usuarios.Remove(dbusuario);
            await _context.SaveChangesAsync();

            return Ok(await _context.Usuarios.ToListAsync());

        }
    }
}
