using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SistemaInvApi.Models;

namespace SistemaInvApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PersonalController : ControllerBase
    {
        private readonly InventarioTicsContext _dbcontext;

        public PersonalController(InventarioTicsContext dbcontext)
        {
            _dbcontext = dbcontext;
        }

        [HttpGet]
        [Route("Lista")]

        public async Task<IActionResult> Lista()
        {
            List<Personal> lista = await _dbcontext.Personals.OrderByDescending(c => c.IdPersonal).ToListAsync();
            return StatusCode(StatusCodes.Status200OK, lista);
        }

        [HttpPost]
        [Route("Guardar")]
        public async Task<IActionResult> Guardar([FromBody] Personal request)
        {
            await _dbcontext.Personals.AddAsync(request);
            await _dbcontext.SaveChangesAsync();

            return StatusCode(StatusCodes.Status200OK, "OK");
        }

        [HttpPut]
        [Route("Editar")]
        public async Task<IActionResult> Editar([FromBody] Personal request)
        {
            _dbcontext.Personals.Update(request);
            await _dbcontext.SaveChangesAsync();

            return StatusCode(StatusCodes.Status200OK, "OK");
        }
        [HttpDelete]
        [Route("Eliminar/{id:int}")]
        public async Task<IActionResult> Eliminar(int id)
        {
            Personal personal = _dbcontext.Personals.Find(id);

            _dbcontext.Personals.Remove(personal);
            await _dbcontext.SaveChangesAsync();

            return StatusCode(StatusCodes.Status200OK, "OK");
        }
    }
}
