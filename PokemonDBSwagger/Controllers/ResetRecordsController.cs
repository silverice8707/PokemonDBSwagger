using Microsoft.AspNetCore.Hosting.Server;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PokemonDBSwagger.Data;
using PokemonDBSwagger.Models;

namespace PokemonDBSwagger.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ResetRecordsController : Controller
    {
        private readonly APIDBContext _db;

        public ResetRecordsController(APIDBContext db)
        {
            _db = db;
        }

        //Removes all entites, truncates the table to reset seeding, and repopulates to the original entities.
        [HttpPost]
        public async Task<IActionResult> ResetRecords()
        {
            _db.Database.ExecuteSqlRaw(
                "TRUNCATE TABLE Pokemons;" +
                "ALTER TABLE Pokemons DROP CONSTRAINT FK_Pokemons_PokemonTypes_TypeAId;" +
                "ALTER TABLE Pokemons DROP CONSTRAINT FK_Pokemons_PokemonTypes_TypeBId;" +
                "TRUNCATE TABLE PokemonTypes;"
                );
            string[] pokemonTypeSRC = System.IO.File.ReadAllLines(@"Files\PokemonTypes.txt");
            List<string> pokemonTypeList = new List<string>(pokemonTypeSRC);

            foreach (var i in pokemonTypeList)
            {
                string[] j = i.Split(",");
                PokemonType pokemonType = new()
                {
                    TypeName = j[0],
                    againstNormal = Convert.ToByte(j[1]),
                    againstFire = Convert.ToByte(j[2]),
                    againstWater = Convert.ToByte(j[3]),
                    againstGrass = Convert.ToByte(j[4]),
                    againstElectric = Convert.ToByte(j[5]),
                    againstIce = Convert.ToByte(j[6]),
                    againstFighting = Convert.ToByte(j[7]),
                    againstPoison = Convert.ToByte(j[8]),
                    againstGround = Convert.ToByte(j[9]),
                    againstFlying = Convert.ToByte(j[10]),
                    againstPsychic = Convert.ToByte(j[11]),
                    againstBug = Convert.ToByte(j[12]),
                    againstRock = Convert.ToByte(j[13]),
                    againstGhost = Convert.ToByte(j[14]),
                    againstDark = Convert.ToByte(j[15]),
                    againstDragon = Convert.ToByte(j[16]),
                    againstSteel = Convert.ToByte(j[17]),
                    againstFairy = Convert.ToByte(j[18])
                };

                _db.PokemonTypes.Add(pokemonType);
                _db.SaveChanges();
            }

            string[] pokemonsSRC = System.IO.File.ReadAllLines(@"Files\Pokemons.txt");
            List<string> pokemonList = new List<string>(pokemonsSRC);

            foreach (var i in pokemonList)
            {
                string[] j = i.Split("|");
                Pokemon pokemon = new()
                {
                    PokedexNumber = j[1],
                    PokemonName = j[2],
                    PokemonTitle = j[4],
                    Description = j[5],
                    TypeAId = Convert.ToByte(j[6]),
                    TypeBId = Convert.ToByte(j[7])
                };

                _db.Pokemons.Add(pokemon);
                _db.SaveChanges();
            }

            _db.Database.ExecuteSqlRaw(
                "ALTER TABLE Pokemons " +
                "ADD CONSTRAINT FK_Pokemons_PokemonTypes_TypeAId FOREIGN KEY(TypeAId) REFERENCES PokemonTypes(Id);" +
                "ALTER TABLE Pokemons " +
                "ADD CONSTRAINT FK_Pokemons_PokemonTypes_TypeBId FOREIGN KEY(TypeBId) REFERENCES PokemonTypes(Id);"
                );
            return Ok();
        }
    }
}