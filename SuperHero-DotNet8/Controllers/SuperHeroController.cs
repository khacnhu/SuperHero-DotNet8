using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SuperHero_DotNet8.Data;
using SuperHero_DotNet8.Entities;

namespace SuperHero_DotNet8.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SuperHeroController : ControllerBase
    {

        private readonly DataContext _context;

        public SuperHeroController(DataContext _context)
        {
            this._context = _context;
        }

        [HttpGet]
        public async Task<ActionResult<List<SuperHero>>> GetAllSuperHero()
        {
           var heros = await this._context.SuperHeroes.ToListAsync();
            return Ok(heros);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<List<SuperHero>>> GetAllSuperHero(int id)
        {
            var hero = await this._context.SuperHeroes.FindAsync(id);
            if (hero is null)
            {
                return BadRequest("super hero with id is not existed");
            }
            return Ok(hero);
        }


        [HttpPost]
        public async Task<ActionResult<List<SuperHero>>> CreateSuperHero(SuperHero superhero)
        {
            _context.SuperHeroes.Add(superhero);
            await _context.SaveChangesAsync();
            return Ok(await _context.SuperHeroes.ToListAsync());
        }


        [HttpPut("{id}")]
        public async Task<ActionResult<List<SuperHero>>> UpdateSuperHero(int id, SuperHero updatedHero)
        {
            var dbHero = await _context.SuperHeroes.FindAsync(id);
            if (dbHero is null)
            {
                return BadRequest("update hero with id is not existed");
            }

            dbHero.FirstName = updatedHero.FirstName;
            dbHero.LastName = updatedHero.LastName;
            dbHero.Name = updatedHero.Name;
            dbHero.Place = updatedHero.Place;

            await _context.SaveChangesAsync();
            return Ok(await _context.SuperHeroes.ToListAsync());


        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<List<SuperHero>>> DeleteSuperHero(int id)
        {
            var hero = await this._context.SuperHeroes.FindAsync(id);
            if (hero is null)
            {
                return BadRequest("super hero with id is not existed");
            }
            _context.SuperHeroes.Remove(hero);
            await _context.SaveChangesAsync();
            return Ok(await _context.SuperHeroes.ToListAsync());
        }

    }
}
