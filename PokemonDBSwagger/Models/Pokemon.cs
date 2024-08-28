using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;
using Swashbuckle.AspNetCore.Annotations;
namespace PokemonDBSwagger.Models
{
    //Column for the table
    public class Pokemon
    {
        [JsonIgnore]
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "This field is required")]
        [StringLength(3)]
        [Display(Name = "Pokedex No.")]
        public string? PokedexNumber { get; set; }

        [Required(ErrorMessage = "This field is required")]
        [StringLength(12)]
        public string? PokemonName { get; set; }


        [Required(ErrorMessage = "This field is required")]
        [StringLength(256)]
        public string? PokemonTitle { get; set; }

        [Required(ErrorMessage = "This field is required")]
        [StringLength(200)]
        public string? Description { get; set; }

        [Required(ErrorMessage = "This field is required")]

        public int? TypeAId { get; set; }
        [JsonIgnore]
        [ForeignKey("TypeAId")]
        public virtual PokemonType? TypeA { get; set; }

        [Required(ErrorMessage = "This field is required")]
        public int? TypeBId { get; set; }
        [JsonIgnore]
        [ForeignKey("TypeBId")]
        public virtual PokemonType? TypeB { get; set; }
    }
}
