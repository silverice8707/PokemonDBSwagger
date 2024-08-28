using PokemonDBSwagger.Models;
using Microsoft.EntityFrameworkCore;
using System.Security.Principal;

namespace PokemonDBSwagger.Data
{
    public class APIDBContext : DbContext
    {
        //DB credentials
        public APIDBContext(DbContextOptions<APIDBContext> options) : base(options)
        {

        }

        //Creating table
        public DbSet<Pokemon> Pokemons { get; set; }
        public DbSet<PokemonType> PokemonTypes { get; set; }

    }
}