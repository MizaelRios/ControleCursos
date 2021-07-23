using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ControleCursos.Data;

namespace ControleCursos.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CursoController : ControllerBase
    {
        private readonly AppDbContext _context;

        public CursoController(AppDbContext context)
        {
            _context = context;
            _context.cursos.Include(c => c.categoria).ToList();
            
        }

        // GET: api/Curso
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Curso>>> GetCursos()
        {
            var cursos = await _context.cursos.ToListAsync();
            
            return cursos;
        }

        // GET: api/Curso/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Curso>> GetCursoById(int id)
        {
            var curso = await _context.cursos.FindAsync(id);

            if (curso == null)
            {
                return BadRequest($"O curso com o código = {id}  não consta na base de dados.");
            }

            return curso;
        }

        // PUT: api/Curso/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCurso(int id, Curso curso)
        {
            if (id != curso.codigo)
            {
                return BadRequest($"O curso com o código = {id} não poderá ser editado pois não consta na base de dados.");
            }

            if (!curso.PeriodoValido(await _context.cursos.ToListAsync(), curso))
            {
                return BadRequest(new { message = $"Existe(m) curso(s) planejado(s) dentro do período informado." });
            }

            if (curso.dataInicio < DateTime.Now)
            {
                return BadRequest(new { message = $"Data início não pode ser menor que data atual." });
            }

            _context.Entry(curso).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CursoExists(id))
                {
                    return BadRequest(new { message = $"O curso com o código = {id} não poderá ser editado pois não consta na base de dados." });
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/Curso
        [HttpPost]
        public async Task<ActionResult<Curso>> PostCurso(Curso curso)
        {
            if (!curso.PeriodoValido(await _context.cursos.ToListAsync(), curso))
            {
                return BadRequest(new { message = $"Existe(m) curso(s) planejado(s) dentro do período informado." });
            }

            if (curso.dataInicio < DateTime.Now)
            {
                return BadRequest(new { message = $"Data início nao pode ser menor que data atual." });
            }

            _context.cursos.Add(curso);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetCurso", new { id = curso.codigo }, curso);
        }

        // DELETE: api/Curso/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCurso(int id)
        {
            var curso = await _context.cursos.FindAsync(id);

            if (curso == null)
            {
                return BadRequest(new { message = $"O curso com o código = {id} não poderá ser excluído pois não consta na base de dados." });
            }

            _context.cursos.Remove(curso);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool CursoExists(int id)
        {
            return _context.cursos.Any(e => e.codigo == id);
        }
    }
}
