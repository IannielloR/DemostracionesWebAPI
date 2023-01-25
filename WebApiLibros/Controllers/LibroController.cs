using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using WebApiLibros.Data;
using WebApiLibros.Moldes;

namespace WebApiLibros.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LibroController : ControllerBase
    {
        private readonly DBLibrosContext context;

        public LibroController(DBLibrosContext context)
        {
            this.context = context;
        }
        // Get
        [HttpGet]
        public ActionResult<IEnumerable<Libro>> GetClinica()
        {
            return context.Libros.ToList();
        }
        //Get por Id
        [HttpGet("{id}")]
        public ActionResult<Libro> GetByID(int id)
        {
            Libro libro = (from l in context.Libros
                           where id == l.Id
                           select l).SingleOrDefault();
            return libro;
        }

        //Get por AutorId
        [HttpGet("autor/{Id}")]
        public ActionResult<IEnumerable<Libro>> GetByAutorID(int id)
        {
            List<Libro> libros = (from l in context.Libros
                           where id == l.AutorId
                           select l).ToList();
            return libros;
        }
        //UPDATE
        //PUT api/autor/{id}
        [HttpPut("{id}")]
        public ActionResult Put(int id, Libro libro)
        {
            if (id != libro.Id)
            {
                return BadRequest();
            }

            context.Entry(libro).State = EntityState.Modified;
            context.SaveChanges();
            return Ok();
        }

        //INSERT
        [HttpPost]
        public ActionResult Post(Libro libro)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            context.Libros.Add(libro);
            context.SaveChanges();
            return Ok();
        }

        //DELETE
        //DELETE api/autor/{id}
        [HttpDelete("{id}")]
        public ActionResult<Libro> Delete(int id)
        {
            var libro = (from p in context.Libros
                         where p.Id == id
                            select p).SingleOrDefault();

            if (libro == null)
            {
                return NotFound();
            }

            context.Libros.Remove(libro);
            context.SaveChanges();

            return libro;

        }
    }
}

