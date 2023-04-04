using GhBrandingBackend.Data;
using GhBrandingBackend.Dtos;
using GhBrandingBackend.Models;
using GhBrandingBackend.Service;
using GhBrandingBackend.Validators;
using Microsoft.AspNetCore.Mvc;

namespace GhBrandingBackend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RegistrosController : ControllerBase
    {
        private readonly RegistrosContext _context;

        public RegistrosController(RegistrosContext context)
        {
            _context = context;
        }

        /// <summary>
        /// Retorna todos os registros.
        /// </summary>
        /// <returns></returns>
        [HttpGet("listar-registros")]
        public ActionResult<Registros> ListarRegistros()
        {
            return Ok(_context.Registros.ToList());
        }

        /// <summary>
        /// Retorna os registros conforme data inicial.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("listar-registros/{id}")]
        public ActionResult<Registros> ListarRegistrosPorData(
            [FromBody] int id)
        {
            return Ok(_context.Registros.
                Where(r => r.Id == id).ToList());
        }

        /// <summary>
        /// Cadastrar Registros.
        /// </summary>
        /// <returns></returns>
        [HttpPost("cadastrar-registros")]
        [ActionName(nameof(CadastrarRegistrosAsync))]
        public async Task<ActionResult<Registros>> CadastrarRegistrosAsync(
            [FromBody] CadastrarRegistrosDto request)
        {
            Registros registros = CadastrarRegistrosService.CadastrarRegistros(request);
            
             CadastrarRegistrosValidator validator = new CadastrarRegistrosValidator();
            var validatorResult = validator.Validate(registros);
            if (!validatorResult.IsValid)
            {
                return BadRequest(validatorResult.Errors.FirstOrDefault());
            }

            _context.Registros.Add(registros);
            await _context.SaveChangesAsync();

            return CreatedAtAction("CadastrarRegistrosAsync", new { id = registros.Id}, registros) ;
        }

        /// <summary>
        /// Excluir Registros.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete("excluir-registros/{id}")]
        public async Task<IActionResult> ExcluirRegistrosAsync(
            int id)
        {
            Registros? registro = await _context.Registros.FindAsync(id);
            if (registro == null)
            {
                return NotFound("Registro não encontrado");
            }

            _context.Registros.Remove(registro);
            await _context.SaveChangesAsync();

            return Ok("Registro excluído com sucesso");
        }
    }
}