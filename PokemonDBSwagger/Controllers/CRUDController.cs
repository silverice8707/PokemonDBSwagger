using Microsoft.AspNetCore.Mvc;
using PokemonDBSwagger.Data;
using System.Text.Json;
using PokemonDBSwagger.Models;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace PokemonDBSwagger.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class CRUDController : Controller
    {
        private readonly APIDBContext _db;

        public CRUDController(APIDBContext db)
        {
            _db = db;
        }

        //Creates new entity
        [HttpPost]
        public IActionResult Create([FromBody] Pokemon pokemonIns)
        {
            if ((pokemonIns.TypeAId <= 0 || pokemonIns.TypeAId >= 19) || (pokemonIns.TypeBId <= 0 || pokemonIns.TypeBId >= 19))
                return BadRequest("Error: Pokemon types should be between 1-18.");

            _db.Pokemons.Add(pokemonIns);
            _db.SaveChanges();
            return Ok("New pokemon added!");
        }

        //Shows all entity within the table
        [HttpGet]
        public IActionResult ReadAll()
        {
            List <Pokemon> res = _db.Pokemons.ToList();
            var jsonString = JToken.FromObject(res).ToString();
            return Ok(jsonString);
        }

        //Shows one entity depending on user input
        [HttpGet]
        public IActionResult ReadOne(int id)
        {
            List<Pokemon> res = _db.Pokemons.Where(p => p.Id == id).Include(x => x.TypeA)
                    .Include(x => x.TypeB).ToList();
            var jsonString = JToken.FromObject(res).ToString();
            return Ok(jsonString);
        }

        //Edits an entity
        [HttpPut]
        public IActionResult Update([FromQuery][Required]int id, [FromBody]Pokemon pokemonIns)
        {
            Pokemon pokemon = _db.Pokemons.Where(x => x.Id == id).SingleOrDefault();
            pokemon.PokedexNumber = pokemonIns.PokedexNumber;
            pokemon.PokemonName = pokemonIns.PokemonName;
            pokemon.PokemonTitle = pokemonIns.PokemonTitle;
            pokemon.Description = pokemonIns.Description;
            pokemon.TypeAId = pokemonIns.TypeAId;
            pokemon.TypeBId = pokemonIns.TypeBId;

            if ((pokemonIns.TypeAId <= 0 || pokemonIns.TypeAId >= 19) || (pokemonIns.TypeBId <= 0 || pokemonIns.TypeBId >= 19))
                return BadRequest("Error: Pokemon types should be between 1-18.");

            _db.Pokemons.Update(pokemon);
            _db.SaveChanges();
            return Ok();
        }

        //Deletes an entity
        [HttpDelete]
        public IActionResult DeleteOne(int id)
        {
            Pokemon pokemon = _db.Pokemons.Where(x => x.Id == id).SingleOrDefault();
            _db.Pokemons.Remove(pokemon);
            _db.SaveChanges();
            return Ok("Successfully removed!");
        }
    }
}
