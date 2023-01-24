using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using WebApiLibros.Data;
using WebApiLibros.Moldes;

namespace WebApiLibros.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AutorController : ControllerBase
    {
        private readonly DBLibrosContext context;

        public AutorController(DBLibrosContext context)
        {
            this.context = context;
        }
        //GET: api/autor/33
        [HttpGet("listado/{edad}")]//ruta personalizada
        public ActionResult<IEnumerable<Autor>> GetEdad(int edad)
        {
            List<Autor> autores = (from a in context.Autores
                                   where a.Edad == edad
                                   select a).ToList();
            return autores;
        }

    }
}
