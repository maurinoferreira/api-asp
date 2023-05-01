using api.Data;
using api.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Security.Principal;

namespace api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PessoasController : ControllerBase
    {

        private readonly ApplicationDbContext _context;

        public PessoasController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<IEnumerable<Pessoa>> Get()
        {

            return await _context.Pessoas.ToListAsync();

        }


        [HttpPost]
        public async Task<IActionResult> Create(Pessoa pessoa)
        {
            if (pessoa != null)
                 _context.Pessoas.Add(pessoa);

                await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetById), new { id = pessoa.Id }, pessoa);

        }

        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetById(int id)
        {
            var pessoa = await _context.Pessoas.FindAsync(id);

            return pessoa == null ? NotFound() : Ok(pessoa);
        
        }

        [HttpGet("nome/{nome}")]
        public async Task<IActionResult> GetByNome(string nome)
        {
            var pessoa = await _context.Pessoas.FirstOrDefaultAsync(p => p.Nome.Equals(nome));

            return pessoa == null ? NotFound() : Ok(pessoa);

        }

        [HttpPut]
        public async Task<IActionResult> Update(Pessoa pessoa)
        {
            var Pessoa = await _context.Pessoas.FindAsync(pessoa.Id);

            if (Pessoa != null) {
                _context.Entry(pessoa).State= EntityState.Modified;
                await _context.SaveChangesAsync();

                return Ok(pessoa);
            }
            return BadRequest();   
           
        
        }

        [HttpDelete("{id:int}")]
        public async Task<IActionResult> Delete(int id)
        {
            var Pessoa = await _context.Pessoas.FindAsync(id);

            if (Pessoa != null)
            {
                _context.Pessoas.Remove(Pessoa);
                await _context.SaveChangesAsync();

                return Ok();
            }
            return BadRequest();
        }

    }
}
