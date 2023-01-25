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
    public class AutorController : ControllerBase
    {


        private readonly DBLibrosContext context;

        public AutorController(DBLibrosContext context)
        {
            this.context = context;
        }
            //GET: api/autor
            [HttpGet]
            public ActionResult<IEnumerable<Autor>> Get()
            {
                return context.Autores.ToList();
                /*var result = context.Autores.Include(x => x.Libros).ToList();
                return result;*/
            }


            // GET api/autor/5
            [HttpGet("{id}")]
            public ActionResult<Autor> GetbyId(int id)
            {
                Autor autor = (from a in context.Autores
                               where a.IdAutor == id
                               select a).SingleOrDefault();

                return autor;

            }
            //POST api/autor
            [HttpPost]
            public ActionResult Post(Autor autor)
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }
                context.Autores.Add(autor);
                context.SaveChanges();
                return Ok();
            }

            //UPDATE
            // PUT api/autor/2
            [HttpPut("{id}")]
            public ActionResult Put(int id, [FromBody] Autor autor)
            {
                if (id != autor.IdAutor)
                {
                    return BadRequest();
                }

                context.Entry(autor).State = EntityState.Modified;
                context.SaveChanges();

                return Ok();

            }
        }
    }
