using SistemaInvApi.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Data;

namespace ApiProyecto.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsuariosController : ControllerBase
    {
        private readonly InventarioTicsContext _dbcontext;

        public UsuariosController(InventarioTicsContext context)
        {

            _dbcontext = context;

        }


        [HttpGet]
        [Route("Lista")]
        public async Task<IActionResult> Lista()
        {
            List<Usuario> lista = await _dbcontext.Usuarios.OrderByDescending(c => c.IdUsuario).ToListAsync();
            return StatusCode(StatusCodes.Status200OK, lista);
        }

        [HttpPost]
        [Route("Guardar")]
        public async Task<IActionResult> Guardar([FromBody] Usuario request)
        {
            await _dbcontext.Usuarios.AddAsync(request);
            await _dbcontext.SaveChangesAsync();

            return StatusCode(StatusCodes.Status200OK, "OK");
        }

        [HttpPut]
        [Route("Editar")]
        public async Task<IActionResult> Editar([FromBody] Usuario request)
        {
            _dbcontext.Usuarios.Update(request);
            await _dbcontext.SaveChangesAsync();

            return StatusCode(StatusCodes.Status200OK, "OK");
        }

        [HttpDelete]
        [Route("Eliminar/{id:int}")]
        public async Task<IActionResult> Eliminar(int id)
        {
            Usuario usuario = _dbcontext.Usuarios.Find(id);

            _dbcontext.Usuarios.Remove(usuario);
            await _dbcontext.SaveChangesAsync();

            return StatusCode(StatusCodes.Status200OK, "Ok");
        }

        
        [HttpPost]
        [Route("Login")]
        public List<Usuario> LoginDetails(Login login)
        {
            try
            {
                var usuarios = InventarioTicsContext.LoginDetails(_dbcontext, login);

                if (usuarios.Count == 0)
                {
                    // Manejar el caso en que no se encuentren usuarios
                    return new List<Usuario>();
                }

                return usuarios;
            }
            catch (Exception)
            {
                // Manejar la excepción según tus necesidades
                return new List<Usuario>();
            }
        }

    }

}


