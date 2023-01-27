using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using API1.Models;

namespace API1.Controllers
{
    [Route("api/Persona")]
    [ApiController]
    public class PersonaController : ControllerBase
    {
        private Models.Api1Context _context;
        public PersonaController(Api1Context context)
        {
            _context = context;
        }

        [HttpGet("Listar")]
        public ActionResult get_Personas()
        {
            List<Persona> lst = new List<Persona>();

            try
            {
                lst = (from data in _context.Personas
                                select data).ToList();
            }catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
            
            return Ok(lst);
        }

        [HttpPost("Guardar")]
        public ActionResult guardar([FromBody] Persona persona)
        {
            try
            {
                _context.Personas.Add(persona);
                _context.SaveChanges();
            }
            catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }

            return Ok(new { msg = "Registro Guardado" });
        }

        [HttpGet("filtrar/{id}")]
        public ActionResult filtrar(int id)
        {
            List<Persona> lst = new List<Persona>();
            try
            {
                lst = (from data in _context.Personas
                       select data).Where(d => d.Id == id).ToList();
            }catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
            return Ok(lst);
        }

        [HttpPut("modificar")]
        public ActionResult modificar([FromBody] Persona oPersona)
        {
            try
            {
                _context.Update(oPersona);
                _context.SaveChanges();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

            return Ok(new { msg = "Registro Modificado" });
        }

        [HttpDelete("Eliminar/{id}")]
        public ActionResult eliminar(int id)
        {
            try
            {
                var oPersona = _context.Personas.Find(id);
                _context.Remove(oPersona);
                _context.SaveChanges();

            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

            return Ok(new { msg = "Registro eliminado" });
        }
    }
}
